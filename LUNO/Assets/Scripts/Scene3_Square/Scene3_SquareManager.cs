using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene3_SquareManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject oldDog;

    [SerializeField]
    private Camera cam;

    CameraController cameraController;
    public GameObject[] bubble;
    public GameObject[] item;

    //only one item
    bool hasItem;
    string hasItemName;
    string getItemName;

    //library
    [SerializeField]
    private GameObject libraryDetail;

    [SerializeField]
    private GameObject noKeyDetail;

    [SerializeField]
    Vector3 libraryPosition;

    Animator detailAnim;

    //dialogue
    [SerializeField]
    private DialogueManager[] dialogueManager;

    //scene
    public GameObject blackScreen;
    Animator blackScreenAnim;

    int sceneNum;

    void Start()
    {
        cameraController = cam.GetComponent<CameraController>();
        blackScreenAnim = blackScreen.GetComponent<Animator>();  
        
        /*
        if(quest1 == 1 && !enterLibrary)
        {
            oldDog.SetActive(true);
            libraryOn = true;
        }
        */
    }
    void Update()
    {
        //collider action
        if (bubble[0].activeSelf & Input.GetKeyDown(KeyCode.E))  //Graveyaed
        {
            bubble[0].SetActive(false);
            SceneManager.LoadScene("Scene2_Graveyard");
        }
        else if (bubble[1].activeSelf && Input.GetKeyDown(KeyCode.E)) //Forest
        {
            bubble[1].SetActive(false);
            //dialogue
            //흙과 나무 냄새
        }
        else if (bubble[2].activeSelf && Input.GetKeyDown(KeyCode.E))   //Lunohouse
        {
            bubble[2].SetActive(false);
            //SceneManager.LoadScene("Scene5_lunohouse");
        }
        else if (bubble[3].activeSelf && Input.GetKeyDown(KeyCode.E))   //Library
        {
            bubble[3].SetActive(false);
            //dialogue
            //도서관 문은 잠겨있어.

            /*
            if (!libraryOn)
            {
                if (dialogueManager[3].GetDone())
                    dialogueManager[3].ResetOrder();
                dialogueManager[3].StartDialogue();
            }
            else if (libraryOn && hasItemName != "key")  //get key
            {
                oldDog.SetActive(false);
                enterLibrary = true;
                dialogueManager[4].StartDialogue();

                libraryDetail.SetActive(true);
                player.GetComponent<Move>().enabled = false;
                player.transform.position = libraryPosition;

                //camera move
                cameraController.targetPosition
                     = new Vector3(cam.transform.position.x + 2.5f, cam.transform.position.y, cam.transform.position.z);
                cameraController.smoothTime = 0.38f;
                cameraController.cameraMove = false;
                cameraController.moveRight = true;
                StartCoroutine(DetailAppear());  //after 0.08s, Detail On

                blackScreenAnim.SetTrigger("FadeOut");
                StartCoroutine(SceneMove());
            }
            else if (hasItemName == "key")   //use key
            {
                blackScreenAnim.SetTrigger("FadeOut");
                StartCoroutine(SceneMove());
            }
            */
        }
        else if (bubble[4].activeSelf && Input.GetKeyDown(KeyCode.E))   //Ladder1
        {
            //dialogue
            //남의 집 사다리에 함부로 올라가는 것은 예의가 아니야.
        }
        else if ((bubble[5].activeSelf || bubble[9].activeSelf)
            && Input.GetKeyDown(KeyCode.E))   //House1, 2
        {
            //dialogue
            //남의 집에 함부로 들어가는 것은 예의가 아니야.
        }
        else if ((bubble[6].activeSelf || bubble[8].activeSelf)
            && Input.GetKeyDown(KeyCode.E))   //Bench1, 2
        {
            //dialogue
            //평범한 벤치야.
        }
        else if (bubble[7].activeSelf && Input.GetKeyDown(KeyCode.E))   //Fountain
        {
            //dialogue
            //우리 마을 중앙에 있는 분수야.
        }

        else if (bubble[10].activeSelf && Input.GetKeyDown(KeyCode.E))   //Babybear
        {
            //animation
            //dialogue
        }

        else if (bubble[11].activeSelf && Input.GetKeyDown(KeyCode.E))   //Otaku
        {
            //dialogue
        }

        else if (bubble[12].activeSelf && Input.GetKeyDown(KeyCode.E))  //Dog
        {
            //dialogue
        }

        else if (bubble[13].activeSelf && Input.GetKeyDown(KeyCode.E))  //OldDog
        {

        }

        /*
        //library enter action
        if (libraryDetail.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            libraryDetail.SetActive(false);
            noKeyDetail.SetActive(true);
            //화면 중앙 하단에 ‘Q 닫기’ 안내 메시지 출력. 5초간 노출 후 사라짐. 
        }

        if (noKeyDetail.activeSelf && Input.GetKeyDown(KeyCode.Q))
        {
            detailAnim = noKeyDetail.GetComponent<Animator>();
            detailAnim.SetTrigger("PressE");
            StartCoroutine(DetailDisappear());
        }
        */
    }

    IEnumerator DetailAppear()
    {
        yield return new WaitForSecondsRealtime(0.08f);
        libraryDetail.SetActive(true);
    }

    IEnumerator DetailDisappear()
    {
        yield return new WaitForSecondsRealtime(1f);
        noKeyDetail.SetActive(false);
        player.GetComponent<Move>().enabled = true;
    }

    IEnumerator SceneMove()
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene("Scene4_Library");
    }
}
