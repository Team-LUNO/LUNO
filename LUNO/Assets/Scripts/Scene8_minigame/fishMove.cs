using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishMove : MonoBehaviour
{

    public GameObject[] fishs;
    private float[] speeds = { 0.3f, 0.7f, 1.0f, 2.3f, 2.5f };
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        for(int i=0; i<fishs.Length; i++)
        {

            if(i==0 || i == 4)
            {
                fishs[i].transform.localPosition += Vector3.left * speeds[i] * Time.deltaTime;
            }
            else
            {
                fishs[i].transform.localPosition += Vector3.right * speeds[i] * Time.deltaTime;
            }
        }
    }
}
