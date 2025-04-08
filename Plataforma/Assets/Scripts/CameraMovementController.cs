using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed;

    public  Vector2 minPosition;
    public  Vector2 maxPosition;

    // Start is called before the first frame update
    void Start()
    {
        GameController.cameraShake = GameObject.FindGameObjectWithTag("CameraShake").GetComponent<CameraShakeController>();
    }

    void LateUpdate()
    {
        if(target != null)
        {
            if(transform.position != target.position)
            {
                Vector3 desiredPosition = target.position;
                desiredPosition.x = Mathf.Clamp(desiredPosition.x, minPosition.x, maxPosition.x);
                desiredPosition.y = Mathf.Clamp(desiredPosition.y, minPosition.y, maxPosition.y);
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
                transform.position = smoothedPosition;
            }   
        }
    }

    public void SetCameraPositionLimit(Vector2 minPosition, Vector2 maxPosition)
    {
        this.minPosition = minPosition;
        this.maxPosition = maxPosition;
    }
   
}
