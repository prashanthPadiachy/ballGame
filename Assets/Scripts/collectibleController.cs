using UnityEngine;

public class collectibleController : MonoBehaviour
{
    [Header("Spin")]
    public Vector3 spinAxis = Vector3.up;
    public float rotationSpeed = 90f;

    [Header("Bob")]
    public float bobHeight = 0.15f;
    public float bobSpeed = 2f;

    [Header("Random Start Angle")]
    public float minTiltX = -15f;
    public float maxTiltX = 15f;
    public float minTiltZ = -10f;
    public float maxTiltZ = 10f;

    private Vector3 startLocalPosition;
    private float bobOffset;

    void Start()
    {
        startLocalPosition = transform.localPosition;

        float randomX = Random.Range(minTiltX, maxTiltX);
        float randomY = Random.Range(0f, 360f);
        float randomZ = Random.Range(minTiltZ, maxTiltZ);

        transform.localRotation = Quaternion.Euler(randomX, randomY, randomZ);

        bobOffset = Random.Range(0f, Mathf.PI * 2f);
    }

    void Update()
    {
        transform.Rotate(spinAxis.normalized, rotationSpeed * Time.deltaTime, Space.Self);

        float newY = startLocalPosition.y + Mathf.Sin((Time.time * bobSpeed) + bobOffset) * bobHeight;

        transform.localPosition = new Vector3(
            startLocalPosition.x,
            newY,
            startLocalPosition.z
        );
    }
}
