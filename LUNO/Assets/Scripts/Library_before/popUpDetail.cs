using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popUpDetail : MonoBehaviour
{
    public GameObject[] sections;
    public GameObject[] details;
    public Camera cam;
    CameraController cameraController;
    Animator detailAnim;
    bool bookshelfOnSwitch = false;
    public int index;
    public bool[] isAnswer;

    [SerializeField]
    private monologue mono;
    [SerializeField]
    private PrologueManager answerPrologue;

    void Start()
    {
        cameraController = cam.GetComponent<CameraController>();
    }

    void Update()
    {
        if (index <2)
        {
            if (!details[index].activeSelf && bookshelfOnSwitch == true && Input.GetKeyDown(KeyCode.E))
            {
                bookshelfOnSwitch = false;
                mono.limitMove(true);

                //카메라 이동
                cameraController.targetPosition
                    = new Vector3(cam.transform.position.x + 2.5f, cam.transform.position.y, cam.transform.position.z);
                cameraController.smoothTime = 0.38f;
                cameraController.cameraMove = false;
                cameraController.moveRight = true;
                StartCoroutine(AppearDelay());
            }
            //closePopUp()으로 옮김
            /*
            else if (details[index].activeSelf && Input.GetKeyDown(KeyCode.E))
            {
                detailAnim = details[index].GetComponent<Animator>();
                detailAnim.SetTrigger("PressE");
                StartCoroutine(DisappearDelay());
                mono.limitMove(false);
            }
            */
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for(int i=0; i<sections.Length; i++)
        {
            if(collision.gameObject == sections[i])
            {
                bookshelfOnSwitch = true;
                index = i;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        for (int i = 0; i < sections.Length; i++)
        {
            if (collision.gameObject == sections[i])
            {
                bookshelfOnSwitch = false;
            }
        }
    }

    public void closePopUp()
    {
        detailAnim = details[index].GetComponent<Animator>();
        detailAnim.SetTrigger("PressE");

        //카메라 이동
        cameraController.targetPosition = cameraController.playerTransform.position;
        cameraController.moveLeft = true;

        isAnswer[index] = true; //일단 다 정답
        if (index == 1)  //마지막 책장 닫을 때
        {
            bool allAnswer = true;
            for (int i = 0; i < isAnswer.Length; i++)
            {
                if (!isAnswer[i])    //정답이 아닌 게 하나라도 있으면
                {
                    allAnswer = false;
                }
            }
            if (allAnswer)
            {
                answerPrologue.StartPrologue();
            }
        }
        StartCoroutine(DisappearDelay());
    }

    IEnumerator AppearDelay()
    {
        yield return new WaitForSecondsRealtime(0.08f);
        details[index].SetActive(true);
        mono.limitMove(false);
    }

    IEnumerator DisappearDelay()
    {
        yield return new WaitForSecondsRealtime(1f);
        details[index].SetActive(false);
        index = 0;
    }
}
