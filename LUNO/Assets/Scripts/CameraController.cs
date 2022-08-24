using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    Vector3 cameraPosition = new Vector3(0, 0, -1);
    public bool cameraMove;

    // 박스 콜라이더 영역의 최소 최대값
    public BoxCollider2D bound;
    private Vector3 minBound;
    private Vector3 maxBound;

    // 카메라의 반넓이와 반높이
    private float halfWidth;
    private float halfHeight;

    //확대
    public bool zoomActive;
    float zoomSpeed = 0f;
    public float zoomSize;  //확대 후 카메라 크기

    //카메라 이동
    public bool moveRight;
    public bool moveLeft;
    Vector3 moveVelocity = Vector3.zero;
    public Vector3 targetPosition;

    public float smoothTime;    //목표도달까지 걸리는 시간

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
        if(moveRight)
        {
            CameraMoveRight();
        }
        if(moveLeft)
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
        //플레이어 위치로 이동
        Vector3 targetPosition = playerTransform.position + cameraPosition;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition,
                                                ref moveVelocity, smoothTime);
        LimitCameraArea();

        //확대
        float smoothZoomSize = Mathf.SmoothDamp(Camera.main.orthographicSize, zoomSize,
                                                ref zoomSpeed, smoothTime);
        Camera.main.orthographicSize = smoothZoomSize;

        //카메라 사이즈 변경됨에 따라 변수 값 변경
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;

        //확대 완료
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

        //이동 완료
        if(Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            moveRight = false;
        }
    }

    void CameraMoveLeft()
    {
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref moveVelocity, smoothTime);

        //이동 완료
        if(Vector3.Distance(transform.position, targetPosition) <0.1f)
        {
            moveLeft = false;
        }
    }
}
