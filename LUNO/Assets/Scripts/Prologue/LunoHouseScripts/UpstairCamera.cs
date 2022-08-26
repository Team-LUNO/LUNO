using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpstairCamera : MonoBehaviour
{
    //Camera Area
    public BoxCollider2D bound;
    private Vector3 minBound;
    private Vector3 maxBound;
    private float halfWidth;
    private float halfHeight;

    public Transform playerTransform;
    CameraController cameraController;
    Vector3 cameraPosition = new Vector3(0, 0, -1);

    [SerializeField]
    Vector3 upstairCamera;

    [SerializeField]
    float upstairPlayer;

    Vector3 moveVelocity = Vector3.zero;
    float smoothTime = 0.5f;
    bool moveUp;
    bool moveDown;
    bool isUpstair;

    void Start()
    {
        minBound = bound.bounds.min;
        maxBound = bound.bounds.max;

        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;

        moveUp = true;
        cameraController = GetComponent<CameraController>();
    }

    void Update()
    {
        //player upstair
        if(playerTransform.position.y >= upstairPlayer)
        {
            cameraController.cameraMove = false;
            moveUp = true;
        }
        //player downstair
        else if(playerTransform.position.y < upstairPlayer)
        {
            isUpstair = false;
            moveUp = false;
            moveDown = true;
        }

        //CameraMove
        if(moveUp)
        {
            CameraMoveUp();
        }
        if(moveDown)
        {
            CameraMoveDown();
        }

        //CameraFixed
        if(isUpstair)
        {
            transform.position = upstairCamera;
        }
    }
    void LimitCameraArea()
    {
        float clampedX = Mathf.Clamp(transform.position.x, minBound.x + halfWidth, maxBound.x - halfWidth);
        float clampedY = Mathf.Clamp(transform.position.y, minBound.y + halfHeight, maxBound.y - halfHeight);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    void CameraMoveUp()
    {
        LimitCameraArea();
        transform.position 
            = Vector3.SmoothDamp(transform.position, upstairCamera, ref moveVelocity, smoothTime);
        if (Vector3.Distance(transform.position, upstairCamera) < 0.1f)
        {
            isUpstair = true;
            moveUp = false;
        }
    }

    void CameraMoveDown()
    {
            LimitCameraArea();
        Vector3 targetPosition = playerTransform.position + cameraPosition;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition,
                                                ref moveVelocity, smoothTime);
        if(Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            moveDown = false;
            cameraController.cameraMove = true;
        }
    }
}
