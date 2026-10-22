using UnityEngine;

public class Goal : MonoBehaviour
{
    [Header("Effects (Optional)")]
    public AudioClip winSound;
    public ParticleSystem winParticles;
    public Light goalLight;

    private bool hasWon = false;

    void Start()
    {
        GetComponent<Collider>().isTrigger = true; Debug.LogWarning("start");
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") || hasWon) return;

        hasWon = true;

        if (winSound != null)
            AudioSource.PlayClipAtPoint(winSound, transform.position);

        if (winParticles != null)
            winParticles.Play();

        if (GameManager.Instance != null)
        {
            Debug.LogWarning("you won");
            GameManager.Instance.Win();
        }
        else
        {
            Debug.LogWarning("Goal reached, but no GameManager found");
        }
    }
}