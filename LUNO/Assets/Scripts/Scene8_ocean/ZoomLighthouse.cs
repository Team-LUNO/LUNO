using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomLighthouse : MonoBehaviour
{
    [SerializeField]
    private CameraController cameraController;

    [SerializeField]
    private Animator lighthouse;

    private bool lightOn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lightOn)
        {
            Invoke("LighthouseAnimPlay", 6f);
            Invoke("ZoomIn", 10f);
            lightOn = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ZoomOut();
        lightOn = true;
    }

    private void ZoomOut()
    {
        cameraController.zoomSize = 24;
        cameraController.smoothTime = 3;
        cameraController.zoomActive = true;
    }

    private void ZoomIn()
    {
        cameraController.zoomSize = 12.6f;
        cameraController.smoothTime = 3;
        cameraController.zoomActive = true;
    }

    private void LighthouseAnimPlay()
    {
        lighthouse.SetBool("lightOn", true);
    }
}
