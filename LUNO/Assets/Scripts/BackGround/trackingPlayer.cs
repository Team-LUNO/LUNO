using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackingPlayer : MonoBehaviour
{
    private float startPos, length;
    public Transform cam;
    public float scale;
    private float halfWidth;
    private float halfHeight;

    void Awake()
    {
        cam = Camera.main.transform;
    }
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;

        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
    }

    void Update()
    {
        float temp = (cam.position.x+halfWidth) * (1 - scale);
        float dist = (cam.position.x+halfWidth) * scale;

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        if (temp > startPos + length)
            startPos += length;
        else if (temp < startPos - length)
            startPos -= length;
    }
}
