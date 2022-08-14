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
        if(cameraMove)
        {
            LimitCameraArea();
        }
    }

    void LimitCameraArea()
    {
        transform.position = playerTransform.position + cameraPosition;

        float clampedX = Mathf.Clamp(transform.position.x, minBound.x + halfWidth, maxBound.x - halfWidth);
        float clampedY = Mathf.Clamp(transform.position.y, minBound.y + halfHeight, maxBound.y - halfHeight);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    public void DetailOn()
    {
        cameraMove = false;
        float smoothrate = 0.5f;
        float targetPosX = Mathf.SmoothDamp(transform.position.x, transform.position.x + 853f, ref smoothrate, 1f);
        Vector3 targetPos = new Vector3(targetPosX, transform.position.y, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, targetPos, Time.deltaTime);
    }

    public void DetailOff()
    {
        Vector3 pos = new Vector3(transform.position.x - 853f, transform.position.y, -1f);
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * 0.5f);
        StartCoroutine(CameraMoveDelay());
    }

    IEnumerator CameraMoveDelay()
    {
        yield return new WaitForSecondsRealtime(1f);
        cameraMove = true;
    }
}
