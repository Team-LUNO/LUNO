using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    Vector3 cameraPosition = new Vector3(0, 0, -1);
    public bool cameraMove;

    //Map Bound
    public BoxCollider2D bound;
    private Vector3 minBound;
    private Vector3 maxBound;

    //Camera size
    private float halfWidth;
    private float halfHeight;

    //Zoom
    public bool zoomActive;
    float zoomSpeed = 0f;
    public float zoomSize;  //camera size after zoom

    //Camera move
    public bool moveRight;
    public bool moveLeft;
    Vector3 moveVelocity = Vector3.zero;
    public Vector3 targetPosition;

    public float smoothTime;

    void Start()
    {
        cameraMove = true;

        minBound = bound.bounds.min;
        maxBound = bound.bounds.max;

        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
    }

    void Update()
    {
        if (cameraMove)
        {
            transform.position = playerTransform.position + cameraPosition;
            LimitCameraArea();
        }
        if (zoomActive)
        {
            ZoomIn();
        }
        if (moveRight)
        {
            CameraMoveRight();
        }
        if (moveLeft)
        {
            CameraMoveLeft();
        }
    }

    void LimitCameraArea()
    {
        float clampedX = Mathf.Clamp(transform.position.x, minBound.x + halfWidth, maxBound.x - halfWidth);
        float clampedY = Mathf.Clamp(transform.position.y, minBound.y + halfHeight, maxBound.y - halfHeight);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    void ZoomIn()
    {
        //Camera Move
        Vector3 targetPosition = playerTransform.position + cameraPosition;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition,
                                                ref moveVelocity, smoothTime);
        LimitCameraArea();

        //Zoom
        float smoothZoomSize = Mathf.SmoothDamp(Camera.main.orthographicSize, zoomSize,
                                                ref zoomSpeed, smoothTime);
        Camera.main.orthographicSize = smoothZoomSize;

        //Camera area change
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;

        //Zoom complete
        if (Mathf.Abs(Camera.main.orthographicSize - zoomSize) < 0.1f)
        {
            halfHeight = Camera.main.orthographicSize;
            halfWidth = halfHeight * Screen.width / Screen.height;
            zoomActive = false;
            cameraMove = true;
        }
    }

    void CameraMoveRight()
    {
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref moveVelocity, smoothTime);

        //Camera move complete
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            moveRight = false;
        }
    }

    void CameraMoveLeft()
    {
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref moveVelocity, smoothTime);

        //Camera move complete
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            moveLeft = false;
            cameraMove = true;
        }
    }
}