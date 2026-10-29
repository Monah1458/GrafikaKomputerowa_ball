using UnityEngine;


[RequireComponent(typeof(Collider))]
public class FanControll : MonoBehaviour
{
    [Header("Wind Settings")]
    [Tooltip("Maximum upward force applied when the player is closest to the fan.")]
    public float maxForce = 25f;

    [Tooltip("How far (in meters) the wind reaches above the fan. At this height, force = 0.")]
    public float windHeight = 8f;

    [Tooltip("Which layers should be affected by the wind.")]
    public LayerMask affectedLayers = ~0; // default: all layers



    [Header("Player Detection")]
    [Tooltip("The tag your player ball uses. Leave as 'Player' by default.")]
    public string playerTag = "Player";

    private Collider triggerZone;

    void Awake()
    {
        triggerZone = GetComponent<Collider>();
        triggerZone.isTrigger = true; // ensure it's a trigger
    }

    void Update()
    {
        

    }

    void OnTriggerStay(Collider other)
    {
        if (((1 << other.gameObject.layer) & affectedLayers) == 0) return;

        if (!other.CompareTag(playerTag)) return;

        Rigidbody rb = other.attachedRigidbody;
        if (rb == null) return;

        float heightDifference = other.bounds.center.y - transform.position.y;
        float t = Mathf.Clamp01(1f - (heightDifference / windHeight));

        float strengthCurve = t * t;

        Vector3 force = Vector3.up * (maxForce * strengthCurve) * rb.mass;
        rb.AddForce(force, ForceMode.Force);


    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(playerTag)) return;

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0.3f, 0.8f, 1f, 0.4f);
        Vector3 basePos = transform.position;
        Vector3 topPos = basePos + Vector3.up * windHeight;

        Gizmos.DrawWireCube(
            (basePos + topPos) / 2f,
            new Vector3(2f, windHeight, 2f)
        );

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(basePos, topPos);
        Gizmos.DrawLine(topPos, topPos + new Vector3(0.5f, -0.5f, 0f));
        Gizmos.DrawLine(topPos, topPos + new Vector3(-0.5f, -0.5f, 0f));
    }
}