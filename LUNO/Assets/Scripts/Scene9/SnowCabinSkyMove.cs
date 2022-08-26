using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowCabinSkyMove : MonoBehaviour
{
    private float startPos, pos, length, endPos;
    public Transform cam;

    void Awake()
    {
        cam = Camera.main.transform;
    }
    void Start()
    {
        startPos = transform.position.x * 2;
        pos = startPos;
        length = GetComponent<SpriteRenderer>().bounds.size.x / 2;
    }


    // Update is called once per frame
    void Update()
    {
        endPos = pos + length;
        if (startPos < endPos)
        {
            pos = transform.position.x;
        }
        else
        {
            transform.position = new Vector3(startPos, transform.position.y, transform.position.z);
            startPos = transform.position.x * 2;
        }

        transform.position += Vector3.left * 0.6f * Time.deltaTime;

    }

}
