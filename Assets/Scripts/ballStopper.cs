using UnityEngine;
using UnityEngine.InputSystem;

public class ballStopper : MonoBehaviour
{
    public InputActionReference move;

    public float stopSpeed = 0.12f;
    public float inputDeadzone = 0.1f;

    Rigidbody rb;
    bool grounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        move.action.Enable();
    }

    void OnDisable()
    {
        move.action.Disable();
    }

    void FixedUpdate()
    {
        Vector2 input = move.action.ReadValue<Vector2>();

        // Don't stop the ball while player is tilting
        if (input.magnitude > inputDeadzone)
        {
            grounded = false;
            return;
        }

        if (!grounded)
        {
            grounded = false;
            return;
        }

        Vector3 horizontalVel = rb.linearVelocity;
        horizontalVel.y = 0f;

        if (horizontalVel.magnitude < stopSpeed)
        {
            rb.linearVelocity = new Vector3(0f, rb.linearVelocity.y, 0f);
            rb.angularVelocity = Vector3.zero;
        }

        grounded = false;
    }

    void OnCollisionStay(Collision collision)
    {
        grounded = true;
    }
}
