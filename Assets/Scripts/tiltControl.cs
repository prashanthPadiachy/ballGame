using UnityEngine;
using UnityEngine.InputSystem;
public class tiltControl : MonoBehaviour
{

    public InputActionReference move;
    public float maxTilt = 15f;
    public float smoothSpeed = 10f;
    public Transform cam;

    Rigidbody rb;
    Quaternion targetRot = Quaternion.identity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        targetRot = rb.rotation;
    }

    private void OnEnable() => move.action.Enable();
    private void OnDisable() => move.action.Disable();


    void FixedUpdate()
    {
        Vector2 input = move.action.ReadValue<Vector2>();

        // If no camera assigned, fall back to old behavior
        if (!cam)
        {
            float tiltX0 = input.y * maxTilt;
            float tiltZ0 = -input.x * maxTilt;
            targetRot = Quaternion.Euler(tiltX0, 0f, tiltZ0);
        }
        else
        {
            // Camera forward/right projected onto ground plane
            Vector3 camF = cam.forward; camF.y = 0f;
            Vector3 camR = cam.right; camR.y = 0f;

            if (camF.sqrMagnitude > 0.0001f) camF.Normalize();
            if (camR.sqrMagnitude > 0.0001f) camR.Normalize();

            // Desired push direction in world space (screen-relative)
            Vector3 dir = camF * input.y + camR * input.x;

            // Convert to tilt around THIS object's local axes
            float tiltX = Vector3.Dot(dir, transform.forward) * maxTilt;
            float tiltZ = -Vector3.Dot(dir, transform.right) * maxTilt;

            targetRot = Quaternion.Euler(tiltX, 0f, tiltZ);
        }

        targetRot.Normalize();

        Quaternion next = Quaternion.Slerp(rb.rotation, targetRot, smoothSpeed * Time.fixedDeltaTime);
        next.Normalize();
        rb.MoveRotation(next);
    }
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
}
