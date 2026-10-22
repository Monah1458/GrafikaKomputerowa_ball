using UnityEngine;

public class PlayerMaterialChange : MonoBehaviour
{
    [Header("Appearance")]
    [Tooltip("The new visual material (texture) for the ball.")]
    public Material newBallMaterial;

    [Header("Physics & Weight")]
    [Tooltip("The new mass (weight) for the ball. Stone = 10, Wood = 1, Paper = 0.1")]
    public float newMass = 1f;

    [Tooltip("Optional: The new Physics Material (friction/bounciness).")]
    public PhysicsMaterial newPhysicMaterial;

    [Header("Effects (Optional)")]
    public AudioClip changeSound;

    private bool hasTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (hasTriggered) return; 

        hasTriggered = true;

  
        Renderer ballRenderer = other.GetComponent<Renderer>();
        if (ballRenderer != null && newBallMaterial != null)
        {
            ballRenderer.material = newBallMaterial;
        }

        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.mass = newMass;
        }

        Collider ballCollider = other.GetComponent<Collider>();
        if (ballCollider != null && newPhysicMaterial != null)
        {
            ballCollider.material = newPhysicMaterial;
        }

        if (changeSound != null)
        {
            AudioSource.PlayClipAtPoint(changeSound, transform.position);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasTriggered = false;
        }
    }
}
