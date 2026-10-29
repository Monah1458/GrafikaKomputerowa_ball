using System.Collections;
using UnityEngine;

public class PlayerMaterialChanger : MonoBehaviour
{
    [Header("Center Detection")]
    [Tooltip("How close the ball center needs to be to the trigger center.")]
    public float centerTolerance = 0.5f;

    [Header("Torus Animation")]
    public Transform torus;
    public float torusMoveDistance = 1.5f;
    public float animationDuration = 2f;

    [Header("Appearance & Physics")]
    public Material newBallMaterial;
    public float newMass = 1f;
    public PhysicsMaterial newPhysicMaterial;
    public AudioClip changeSound;
    private bool hasBeenUsed = false;
    private bool isAnimating = false;
    private Vector3 torusStartPos;
    private Collider triggerZone; 

    void Start()
    {
        if (torus != null)
            torusStartPos = torus.localPosition;

        
        triggerZone = GetComponent<Collider>();
        if (triggerZone == null)
            Debug.LogError("No Collider found on the Material Changer Block!");
    }

    void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player") || isAnimating || hasBeenUsed || triggerZone == null) return;

        
        Vector3 triggerCenter = triggerZone.bounds.center;
        Vector3 playerPos = other.bounds.center;


        Vector2 flatTriggerPos = new Vector2(triggerCenter.x, triggerCenter.z);
        Vector2 flatPlayerPos = new Vector2(playerPos.x, playerPos.z);
        float distance = Vector2.Distance(flatTriggerPos, flatPlayerPos);

        Debug.Log("Distance to center: " + distance);

        if (distance <= centerTolerance)
        {
            StartCoroutine(ChangeSequence(other));
        }
    }

    private IEnumerator ChangeSequence(Collider player)
    {

        isAnimating = true;
        hasBeenUsed=true;
        Debug.Log("Player entered center! Freezing...");

        Rigidbody rb = player.GetComponent<Rigidbody>();
        PlayerController controller = player.GetComponent<PlayerController>();

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero; 
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
        }

        if (controller != null) controller.enabled = false;

        if (changeSound != null)
        {
            Debug.Log("Playing sound: " + changeSound.name); // <-- Add this line
            AudioSource.PlayClipAtPoint(changeSound, transform.position);
        }
        else
        {
            Debug.LogError("Sound is missing from the Inspector!"); // <-- Add this line
        }
        if (changeSound != null) AudioSource.PlayClipAtPoint(changeSound, transform.position);

        float elapsed = 0f;
        float halfDuration = animationDuration / 2f;
        bool materialChanged = false;

        while (elapsed < animationDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / animationDuration;

            if (torus != null)
            {
                float offsetY = Mathf.Sin(t * Mathf.PI) * torusMoveDistance;
                torus.localPosition = torusStartPos + new Vector3(0, offsetY, 0);
            }

            if (!materialChanged && elapsed >= halfDuration)
            {
                materialChanged = true;
                ApplyChanges(player);
            }

            yield return null;
        }

        if (torus != null) torus.localPosition = torusStartPos;

        if (rb != null) rb.isKinematic = false;
        if (controller != null) controller.enabled = true;

        yield return new WaitForSeconds(0.5f);
        isAnimating = false;
    }

    private void ApplyChanges(Collider player)
    {
        Renderer ballRenderer = player.GetComponent<Renderer>();
        if (ballRenderer != null && newBallMaterial != null) ballRenderer.material = newBallMaterial;

        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null) rb.mass = newMass;

        if (player != null && newPhysicMaterial != null) player.material = newPhysicMaterial;
    }

    void OnDrawGizmos()
    {
        Collider col = GetComponent<Collider>();
        if (col != null)
        {
            Gizmos.color = Color.yellow;
            Vector3 center = col.bounds.center;
            Gizmos.DrawWireSphere(new Vector3(center.x, center.y, center.z), centerTolerance);
        }
    }
}