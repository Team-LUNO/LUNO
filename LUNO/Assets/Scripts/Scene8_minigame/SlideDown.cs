using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDown : MonoBehaviour
{
    public Camera cam;

    private void Start()
    {
        StartCoroutine(Slide());
    }

    IEnumerator Slide()
    {
        yield return new WaitForSeconds(2.0f);
        Debug.Log(cam.transform.localPosition);
    }
}
