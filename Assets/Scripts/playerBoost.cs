using UnityEngine;

public class playerBoost : MonoBehaviour
{
    public float slopeBoost = 25f;
    Rigidbody rb;
    Vector3 groundNormal = Vector3.up;

    void Awake() => rb = GetComponent<Rigidbody>();

    void OnCollisionStay(Collision col)
    {
        foreach (ContactPoint contact in col.contacts)
        {
            groundNormal = contact.normal;
            break;
        }
    }

    void FixedUpdate()
    {
        Vector3 downhill = Vector3.ProjectOnPlane(Vector3.down, groundNormal).normalized;
        rb.AddForce(downhill * slopeBoost, ForceMode.Acceleration);
    }
}
