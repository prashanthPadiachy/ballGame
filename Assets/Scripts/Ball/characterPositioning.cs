using UnityEngine;

public class characterPositioning : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private Transform camTransform;
    [SerializeField] private float yOffset = -0.495f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPos = targetTransform.position;
        newPos.y += yOffset;
        transform.position = newPos;

        transform.rotation = camTransform.rotation;
    }
}
