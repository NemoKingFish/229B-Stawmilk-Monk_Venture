using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [SerializeField] private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform target;

    private void Update()
    {
        float targetX = target.position.x + offset.x;
        float fixedY = transform.position.y; 
        float fixedZ = offset.z;             

        Vector3 targetPosition = new Vector3(targetX, fixedY, fixedZ);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}

