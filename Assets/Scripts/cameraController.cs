using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class cameraController : MonoBehaviour
{

    public float distance = 10f;
    public float height = 3f;
    public float pitchAngle = 20f;
    public float rotateSpeed = 6f;

    public float posSmooth = 8f;

    public Transform target;

    Rigidbody targetRb;
    float currentYaw;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (target) targetRb = target.GetComponent<Rigidbody>();
        currentYaw = transform.eulerAngles.y;
    }

    void LateUpdate()
    {
        if (!target) return;

        Vector3 vel = targetRb ? targetRb.linearVelocity : Vector3.zero;
        vel.y = 0;

        if (vel.magnitude > 0.2f)
        {
            float targetYaw = Quaternion.LookRotation(vel).eulerAngles.y;
            currentYaw = Mathf.LerpAngle(currentYaw, targetYaw, rotateSpeed * Time.deltaTime);
        }

        Quaternion rot = Quaternion.Euler(pitchAngle, currentYaw, 0);
        Vector3 offset = rot * new Vector3(0, 0, -distance);

        Vector3 desiredPos = target.position + offset + Vector3.up * height;

        transform.position = Vector3.Lerp(transform.position, desiredPos, posSmooth * Time.deltaTime);
        transform.rotation = rot;
    }
}
