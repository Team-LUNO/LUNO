using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCameraController : MonoBehaviour
{
    public BoxCollider2D bound;
    private Vector3 minBound;
    private Vector3 maxBound;

    private float halfWidth;
    private float halfHeight;

    public bool zoomActive;
    float zoomSpeed = 0f;
    public float zoomSize;  

    Vector3 moveVelocity = Vector3.zero;
    public Vector3 targetPosition;

    public float smoothTime;    

    public GameObject mainCamera;

    void Start()
    {
        minBound = bound.bounds.min;
        maxBound = bound.bounds.max;

        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;

        LimitCameraArea();
    }

    void Update()
    {
        if (zoomActive)
        {
            ZoomIn();
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
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition,
                                                ref moveVelocity, smoothTime);
        LimitCameraArea();

        float smoothZoomSize = Mathf.SmoothDamp(Camera.main.orthographicSize, zoomSize,
                                                ref zoomSpeed, smoothTime);
        Camera.main.orthographicSize = smoothZoomSize;

        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;

        if (Mathf.Abs(Camera.main.orthographicSize - zoomSize) < 0.1f)
        {
            halfHeight = Camera.main.orthographicSize;
            halfWidth = halfHeight * Screen.width / Screen.height;
            zoomActive = false;
            mainCamera.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
