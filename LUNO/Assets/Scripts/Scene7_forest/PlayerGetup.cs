using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetup : MonoBehaviour
{
    public GameObject player;
    public FirstCameraController cam;
    Animator getupAnim;
    Animator anim;
    Move move;

    [SerializeField]
    private PrologueManager prologueManager;

    [SerializeField]
    Vector3 getUpPos;

    public GameObject firstCamera;
    public GameObject mainCamera;

    void Start()
    {
        move = player.GetComponent<Move>();
        anim = player.GetComponent<Animator>();
        getupAnim = GetComponent<Animator>();

        anim.runtimeAnimatorController = getupAnim.runtimeAnimatorController;

        move.enabled = false;
        StartCoroutine(ZoomIn());
    }

    void Update()
    {

    }
    IEnumerator ZoomIn()
    {
        //�� �ƿ��� ���¿��� 2�� ���� �� �� ����
        yield return new WaitForSecondsRealtime(2f);
        cam.zoomSize = 14f;
        cam.smoothTime = 0.5f;
        cam.zoomActive = true;
        cam.targetPosition = getUpPos;
        StartCoroutine(Getup());
    }

    IEnumerator Getup()
    {
        //2�� ���� �� �Ͼ��
        yield return new WaitForSecondsRealtime(2.1f);
        anim.SetTrigger("GetUp");
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        //�ִϸ��̼� ���� ��
        yield return new WaitForSecondsRealtime(3f);
        move.enabled = true;
        anim.runtimeAnimatorController = move.rWalk.runtimeAnimatorController;
        player.transform.position = getUpPos;

        //ī�޶� ��ȯ
        mainCamera.transform.position = firstCamera.transform.position;
        mainCamera.GetComponent<Camera>().orthographicSize
            = firstCamera.GetComponent<Camera>().orthographicSize;
        mainCamera.SetActive(true);
        firstCamera.SetActive(false);

        StartCoroutine(MuneTalk());
    }

    IEnumerator MuneTalk()
    {
        //1�� ���� �� �� ��� 
        yield return new WaitForSecondsRealtime(1f);
        prologueManager.StartPrologue();
    }
}
