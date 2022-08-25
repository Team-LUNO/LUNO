using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetup : MonoBehaviour
{
    public GameObject player;
    public Animator getup;
    public FirstCameraController cam;
    Animator anim;
    Move move;

    public Camera firstCamera;
    public Camera mainCamera;

    [SerializeField]
    private PrologueManager prologueManager1;

    [SerializeField]
    Vector3 getUpPos;

    void Start()
    {
        move = player.GetComponent<Move>();
        anim = player.GetComponent<Animator>();

        anim.runtimeAnimatorController = getup.runtimeAnimatorController;

        move.isOn = false;
        StartCoroutine(ZoomIn());
    }

    void Update()
    {

    }
    IEnumerator ZoomIn()
    {
        yield return new WaitForSecondsRealtime(2f);
        cam.zoomSize = 14f;
        cam.smoothTime = 0.5f;
        cam.targetPosition = getUpPos;
        cam.zoomActive = true;
        StartCoroutine(Getup());
    }

    IEnumerator Getup()
    {
        yield return new WaitForSeconds(5f);
        anim.SetTrigger("GetUp");
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(2.6f);
        move.isOn = true;
        player.transform.position = getUpPos;
        anim.runtimeAnimatorController = move.rWalk.runtimeAnimatorController;
        StartCoroutine(MuneTalk());
    }

    IEnumerator MuneTalk()
    {
        yield return new WaitForSeconds(1f);
        prologueManager1.StartPrologue();
    }
}
