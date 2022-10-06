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
    bool isUpstair;
    bool isDownstair;

    void Start()
    {
        minBound = bound.bounds.min;
        maxBound = bound.bounds.max;

        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;

        cameraController = GetComponent<CameraController>();
        isUpstair = true;
        cameraController.cameraMove = false;
    }

    void Update()
    {
        //Camera Move
        //Player Downstair -> Upstair
        if(!isUpstair && playerTransform.position.y >= upstairPlayer)
        {
            isDownstair = false;
            cameraController.cameraMove = false;
            CameraMoveUp();
        }
        //Player Downstair -> Upstair
        else if(!isDownstair && playerTransform.position.y < upstairPlayer)
        {
            isUpstair = false;
            cameraController.cameraMove = false;
            CameraMoveDown();
        }

        //Camera Fixed
        if(isUpstair)
        {
            transform.position = upstairCamera;
        }
        else if(isDownstair)
        {
            cameraController.cameraMove = true;
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
        if (Vector3.Distance(transform.position, upstairCamera) < 0.2f)
        {
            isUpstair = true;
        }
    }

    void CameraMoveDown()
    {
        LimitCameraArea();
        Vector3 targetPosition = playerTransform.position + cameraPosition;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition,
                                                ref moveVelocity, smoothTime);
        if(Vector3.Distance(transform.position, targetPosition) < 1.3f)
        {
            isDownstair = true;
        }
    }
}
