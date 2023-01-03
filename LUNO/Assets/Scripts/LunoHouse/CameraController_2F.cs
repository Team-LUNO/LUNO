using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController_2F : MonoBehaviour
{
    public Transform playerTransform;
    Vector3 cameraPosition = new Vector3(0, 0, -1);

    //Map Bound
    public BoxCollider2D bound;
    private Vector3 minBound;
    private Vector3 maxBound;

    //Camera size
    private float halfWidth;
    private float halfHeight;

    void Start()
    {
        minBound = bound.bounds.min;
        maxBound = bound.bounds.max;

        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
    }

    void Update()
    {
        transform.position = playerTransform.position + cameraPosition;
        LimitCameraArea();
    }

    void LimitCameraArea()
    {
        float clampedX = Mathf.Clamp(transform.position.x, minBound.x + halfWidth, maxBound.x - halfWidth);
        float clampedY = Mathf.Clamp(transform.position.y, minBound.y + halfHeight, maxBound.y - halfHeight);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
