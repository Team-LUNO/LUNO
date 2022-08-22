using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    public Transform player;

    Vector2 targetPosition;
    float zoomSize = 11f;
    float zoomSpeed = 0f;
    float smoothTime = 0.2f;
    Vector2 moveVelocity = Vector2.zero;

    void Start()
    {
        //ZoomIn();
    }

    void Update()
    {
        ZoomIn();

    }

    void ZoomIn()
    {
        Debug.Log("¡‹¿Œ");
        targetPosition = player.transform.position;
        Vector2 smoothPosition = Vector2.SmoothDamp(transform.position, targetPosition,
                                                    ref moveVelocity, smoothTime);
        transform.position = smoothPosition;
        float smoothZoomSize = Mathf.SmoothDamp(Camera.main.orthographicSize, zoomSize,
                                                ref zoomSpeed, smoothTime);
        Camera.main.orthographicSize = smoothZoomSize;
    }
}
