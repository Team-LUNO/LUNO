using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // �ڽ� �ö��̴� ������ �ּ� �ִ밪
    public BoxCollider2D bound;
    private Vector3 minBound;
    private Vector3 maxBound;

    // ī�޶��� �ݳ��̿� �ݳ����� �� ����
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
        LimitCameraArea();
    }

    void LimitCameraArea()
    {
        float clampedX = Mathf.Clamp(this.transform.position.x, minBound.x + halfWidth, maxBound.x - halfWidth);
        float clampedY = Mathf.Clamp(this.transform.position.y, minBound.y + halfHeight, maxBound.y - halfHeight);

        this.transform.position = new Vector3(clampedX, clampedY, this.transform.position.z);
    }
}
