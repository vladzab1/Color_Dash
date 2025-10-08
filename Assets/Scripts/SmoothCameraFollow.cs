using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    [Header("Target settings")]
    public Transform target; 

    [Header("Smooth settings")]
    public float smoothTime = 0.3f; 
    public Vector3 offset = new Vector3(0, 0, -10); 

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target == null) return;

        
        
        
        Vector3 targetPosition = target.position + offset;


        
        transform.position = Vector3.SmoothDamp(
            transform.position, 
            targetPosition, 
            ref velocity, 
            smoothTime
        );
    }
}
