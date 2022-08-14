using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBalloonScale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localScale = new Vector3(1.0f / gameObject.transform.parent.lossyScale.x, 1.0f / gameObject.transform.parent.lossyScale.y, 1.0f / gameObject.transform.parent.lossyScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
