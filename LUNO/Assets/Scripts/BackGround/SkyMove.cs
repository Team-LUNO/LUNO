using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyMove : MonoBehaviour
{
    private float length;

    [SerializeField]
    private float offset;

    [SerializeField]
    private Transform[] backgrounds;


    private float leftPosX = 0f;
    private float rightPosX = 0f;
    private float xScreenHalfSize = 0f;
    private float yScreenHalfSize = 0f;

    void Start()
    {
        float tLength = backgrounds[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        yScreenHalfSize = Camera.main.orthographicSize;
        xScreenHalfSize = yScreenHalfSize * Camera.main.aspect;

        leftPosX = -(xScreenHalfSize * 2.15f);
        rightPosX = xScreenHalfSize * 2.15f * backgrounds.Length + offset;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].position += Vector3.left * 1f * Time.deltaTime;

            if (backgrounds[i].position.x < leftPosX)
            {
                Vector3 nextPos = backgrounds[i].position;
                nextPos = new Vector3(nextPos.x + rightPosX, nextPos.y, nextPos.z);
                backgrounds[i].position = nextPos;
            }
        }
    }

}
