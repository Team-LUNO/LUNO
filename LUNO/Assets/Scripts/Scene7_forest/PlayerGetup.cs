using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetup : MonoBehaviour
{
    public GameObject player;
    public Animator getup;
    public CameraController cam;
    Animator anim;
    Move move;

    bool zoomActive;
    float zoomSize = 11f;

    void Start()
    {
        move = player.GetComponent<Move>();
        anim = player.GetComponent<Animator>();

        move.isOn = false;
        anim.runtimeAnimatorController = getup.runtimeAnimatorController;
    }

    void Update()
    {
        if(zoomActive)
        {
            cam.ZoomIn(zoomSize);
        }
    }

    public void Getup()
    {
        cam.cameraMove = false;
        move.isOn = true;
        anim.runtimeAnimatorController = move.rWalk.runtimeAnimatorController;
        zoomActive = true;
    }
}
