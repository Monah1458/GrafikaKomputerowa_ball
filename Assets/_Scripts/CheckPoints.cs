using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Checkpoint : MonoBehaviour
{
    [Tooltip("Reference point for the respawn")]
    public Transform spawnPoint;

    [Header("Visuals")]
    public Renderer glowRenderer;
    public Color inactiveColor = Color.gray;
    public Color activeColor = Color.green;

    private bool isActive;

    void Start()
    {
        var col = GetComponent<Collider>();
        col.isTrigger = true;
        gameObject.layer = LayerMask.NameToLayer("Checkpoint");

        if (glowRenderer != null)
            SetGlow(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (isActive) return;
        if (!other.CompareTag("Player")) return;

        PlayerRespawn respawn = other.GetComponent<PlayerRespawn>();
        if (respawn == null) return;

        Vector3 pos = spawnPoint != null ? spawnPoint.position : transform.position;
        Quaternion rot = spawnPoint != null ? spawnPoint.rotation : Quaternion.identity;

        respawn.SetCheckpoint(pos, rot);
        isActive = true;
        SetGlow(true);
        Debug.Log($"Checkpoint activated: {name}");
    }

    private void SetGlow(bool on)
    {
        if (glowRenderer == null) return;
        glowRenderer.material.color = on ? activeColor : inactiveColor;
    }
}