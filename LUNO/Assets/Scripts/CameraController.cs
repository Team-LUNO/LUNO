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

    static public CameraController instance; // �� ��ȯ���� ���� ������

    //Ȯ��
    public bool zoomActive;
    float zoomSpeed = 0f;
    public float zoomSize;  //Ȯ�� �� ī�޶� ũ��

    //ī�޶� �̵�
    public bool moveRight;
    public bool moveLeft;
    Vector3 moveVelocity = Vector3.zero;
    public Vector3 targetPosition;

    public float smoothTime;    //��ǥ���ޱ��� �ɸ��� �ð�

    void Start()
    {
        cameraMove = true;

        minBound = bound.bounds.min;
        maxBound = bound.bounds.max;

        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;

        if (instance == null) // �� ��ȯ���� ���� ������
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
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
        //�÷��̾� ��ġ�� �̵�
        Vector3 targetPosition = playerTransform.position + cameraPosition;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition,
                                                ref moveVelocity, smoothTime);
        LimitCameraArea();

        //Ȯ��
        float smoothZoomSize = Mathf.SmoothDamp(Camera.main.orthographicSize, zoomSize,
                                                ref zoomSpeed, smoothTime);
        Camera.main.orthographicSize = smoothZoomSize;

        //ī�޶� ������ ����ʿ� ���� ���� �� ����
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;

        //Ȯ�� �Ϸ�
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

        //�̵� �Ϸ�
        if(Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            moveRight = false;
        }
    }

    void CameraMoveLeft()
    {
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref moveVelocity, smoothTime);

        //�̵� �Ϸ�
        if(Vector3.Distance(transform.position, targetPosition) <0.1f)
        {
            moveLeft = false;
            cameraMove = true;
        }
    }
}
