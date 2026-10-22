using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [Header("Respawn")]
    [Tooltip("Height below which the player automatically respawns.")]
    public float fallLimitY = -20f;

    [Tooltip("Delay in seconds before respawning after falling/trigger.")]
    public float respawnDelay = 0.5f;

    [Header("Effects (optional)")]
    public GameObject deathEffectPrefab;   // particle prefab
    public AudioClip deathSound;
    public AudioClip respawnSound;

    private Vector3 currentCheckpoint;
    private Quaternion currentCheckpointRotation = Quaternion.identity;
    private Rigidbody rb;
    private PlayerController controller;
    private AudioSource audioSource;
    private bool isRespawning;

    public Vector3 CurrentCheckpoint => currentCheckpoint;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<PlayerController>();
        audioSource = GetComponent<AudioSource>();
        currentCheckpoint = transform.position;
        currentCheckpointRotation = transform.rotation;
    }

    void Update()
    {
        // Auto-respawn if fallen below the limit
        if (!isRespawning && transform.position.y < fallLimitY)
        {
            Respawn();
        }
    }

    public void SetCheckpoint(Vector3 position, Quaternion rotation)
    {
        currentCheckpoint = position;
        currentCheckpointRotation = rotation;
    }

    public void Respawn()
    {
        if (isRespawning) return;
        StartCoroutine(RespawnRoutine());
    }

    private System.Collections.IEnumerator RespawnRoutine()
    {
        isRespawning = true;

        if (deathEffectPrefab != null)
            Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
        if (audioSource != null && deathSound != null)
            audioSource.PlayOneShot(deathSound);

        // Freeze input briefly
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        yield return new WaitForSeconds(respawnDelay);

        // Move to checkpoint
        rb.position = currentCheckpoint;
        transform.position = currentCheckpoint;
        transform.rotation = currentCheckpointRotation;
        //if (controller != null) controller.ResetForRespawn();

        if (audioSource != null && respawnSound != null)
            audioSource.PlayOneShot(respawnSound);

        isRespawning = false;
    }

    // ──────────────────────────────────────────────
    //  KillZone support (trigger objects)
    // ──────────────────────────────────────────────
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillZone"))
            Respawn();
    }
}