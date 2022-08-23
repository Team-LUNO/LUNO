using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    Vector3 cameraPosition = new Vector3(0, 0, -1);
    public bool cameraMove;

    // �ڽ� �ݶ��̴� ������ �ּ� �ִ밪
    public BoxCollider2D bound;
    private Vector3 minBound;
    private Vector3 maxBound;

    // ī�޶��� �ݳ��̿� �ݳ���
    private float halfWidth;
    private float halfHeight;

    //����
    float zoomSpeed = 0f;
    float smoothTime = 0.5f;    //��ǥ���ޱ��� �ɸ��� �ð�
    Vector3 moveVelocity = Vector3.zero;

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
    }

    void LimitCameraArea()
    {
        float clampedX = Mathf.Clamp(transform.position.x, minBound.x + halfWidth, maxBound.x - halfWidth);
        float clampedY = Mathf.Clamp(transform.position.y, minBound.y + halfHeight, maxBound.y - halfHeight);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    public void ZoomIn(float size)    //size: ���� ����
    {
        //�÷��̾� ��ġ�� �̵�
        Vector3 targetPosition = playerTransform.position + cameraPosition;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition,
                                                ref moveVelocity, smoothTime);
        LimitCameraArea();

        //����
        float smoothZoomSize = Mathf.SmoothDamp(Camera.main.orthographicSize, size,
                                                ref zoomSpeed, smoothTime);
        Camera.main.orthographicSize = smoothZoomSize;

        //ī�޶� ������ ����ʿ� ���� ���� �� ����
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;

        //���� �Ϸ�
        if (Mathf.Abs(Camera.main.orthographicSize - size) < 0.1f)
        {
            halfHeight = Camera.main.orthographicSize;
            halfWidth = halfHeight * Screen.width / Screen.height;
            cameraMove = true;
        }
    }
}
