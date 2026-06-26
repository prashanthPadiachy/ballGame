using UnityEngine;

public class BallRollingResistance : MonoBehaviour
{
    public float rollingResistance = 0.8f;
    public float stopSpeed = 0.15f;

    Rigidbody rb;
    bool grounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (!grounded) return;

        Vector3 horizontalVelocity = rb.linearVelocity;
        horizontalVelocity.y = 0f;

        if (horizontalVelocity.magnitude < stopSpeed)
        {
            rb.linearVelocity = new Vector3(0f, rb.linearVelocity.y, 0f);
            rb.angularVelocity = Vector3.zero;
            return;
        }

        rb.AddForce(-horizontalVelocity * rollingResistance, ForceMode.Acceleration);

        grounded = false;
    }

    void OnCollisionStay(Collision collision)
    {
        grounded = true;
    }
}
