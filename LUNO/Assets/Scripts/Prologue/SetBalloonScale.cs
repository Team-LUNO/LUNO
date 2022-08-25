using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBalloonScale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float x = (1.0f / gameObject.transform.parent.lossyScale.x) / (9.0f / Camera.main.orthographicSize);
        float y = (1.0f / gameObject.transform.parent.lossyScale.y) / (9.0f / Camera.main.orthographicSize);
        float z = (1.0f / gameObject.transform.parent.lossyScale.z) / (9.0f / Camera.main.orthographicSize);

        gameObject.transform.localScale = new Vector3(x, y, z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
