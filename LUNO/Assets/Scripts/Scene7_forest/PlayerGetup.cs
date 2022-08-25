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

    [SerializeField]
    private PrologueManager prologueManager1;

    void Start()
    {
        move = player.GetComponent<Move>();
        anim = player.GetComponent<Animator>();

        move.isOn = false;
        anim.runtimeAnimatorController = getup.runtimeAnimatorController;
        StartCoroutine(Getup());
    }

    void Update()
    {

    }

    IEnumerator Getup()
    {
        yield return new WaitForSeconds(2.6f);
        move.isOn = true;
        anim.runtimeAnimatorController = move.rWalk.runtimeAnimatorController;
        cam.cameraMove = false;
        cam.zoomSize = 14f;
        cam.smoothTime = 0.5f;
        cam.zoomActive = true;
        StartCoroutine(MuneTalk());
    }

    IEnumerator MuneTalk()
    {
        yield return new WaitForSeconds(1f);
        prologueManager1.StartPrologue();
    }
}
