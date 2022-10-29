using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Playables;

public class Scene3_SquareManager : MonoBehaviour
{
    public int sceneNum;

    [SerializeField]
    private PlayableDirector[] director;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Vector3[] startPosition;

    [SerializeField]
    private GameObject[] InfoUI;

    [SerializeField]
    private bool infoUISwitch;

    [SerializeField]
    private GameObject oldDog;

    [SerializeField]
    private Camera cam;

    CameraController cameraController;
    public GameObject[] bubble;
    public GameObject[] item;
    private float noMoveTime = 0f;

    [SerializeField]
    private GameObject graveyardBubble;

    [SerializeField]
    private GameObject flowerBubble;

    int benchDialogue = 0;

    //library
    [SerializeField]
    private GameObject libraryDetail;

    [SerializeField]
    private GameObject noKeyDetail;

    [SerializeField]
    Vector3 libraryPosition;

    Animator animator;

    //dialogue
    [SerializeField]
    private DialogueManager[] dialogueManager;

    //scene
    public GameObject blackScreen;

    void Start()
    {
        cameraController = cam.GetComponent<CameraController>();
        animator = blackScreen.GetComponent<Animator>();

        if (sceneNum == 2 && !infoUISwitch)
        {
            player.transform.position = startPosition[0];
            director[0].Play();
            infoUISwitch = true;
        }
        else if (sceneNum == 2 && infoUISwitch)
        {
            director[1].Play();
            player.transform.position = startPosition[1];
        }
        else if (sceneNum == 3)
        {

        }
    }
    void Update()
    {
        //collider action
        if (sceneNum == 2)
        {
            if (bubble[0].activeSelf & Input.GetKeyDown(KeyCode.E))  //Graveyard
            {
                bubble[0].SetActive(false);
                SceneManager.LoadScene("Scene2_Graveyard");
            }
            else if (bubble[1].activeSelf && Input.GetKeyDown(KeyCode.E)) //Forest
            {
                bubble[1].SetActive(false);
                //S2-2s-1 dialogue
            }
            else if (bubble[2].activeSelf && Input.GetKeyDown(KeyCode.E))   //Lunohouse
            {
                bubble[2].SetActive(false);
                //SceneManager.LoadScene("Scene5_lunohouse");
            }
            else if (bubble[3].activeSelf && Input.GetKeyDown(KeyCode.E))   //Library
            {
                bubble[3].SetActive(false);
                //S2-2s-2 dialogue
            }
            else if (bubble[4].activeSelf && Input.GetKeyDown(KeyCode.E))   //Ladder1
            {
                //S2-2s-3 dialogue
            }
            else if (bubble[5].activeSelf && Input.GetKeyDown(KeyCode.E))   //House1
            {
                //S2-2s-4 dialogue
            }
            else if ((bubble[6].activeSelf || bubble[8].activeSelf)
            && Input.GetKeyDown(KeyCode.E))   //Bench1, 2
            {
                if (benchDialogue == 0)
                {
                    //S2-2s-5 dialogue
                    benchDialogue++;
                }
                else
                {
                    //S2-2s-6 dialogue
                    benchDialogue--;
                }
            }
            else if (bubble[7].activeSelf && Input.GetKeyDown(KeyCode.E))   //Fountain
            {
                //S2-2s-7 dialogue
            }
            else if (bubble[9].activeSelf && Input.GetKeyDown(KeyCode.E))   //House2
            {
                //S2-2s-9
            }

            //bubble[10]. babybear dialogue S2-2s-8

            else if (bubble[11].activeSelf && Input.GetKeyDown(KeyCode.E))   //Otaku
            {
                //S2-2s-10 dialogue
            }
            else if (bubble[12].activeSelf && Input.GetKeyDown(KeyCode.E))  //Dog
            {
                //S2-2s-11 dialogue
            }

            //no move for 5 secnods
            noMoveTime += Time.deltaTime;

            if (Input.anyKeyDown)
            {
                noMoveTime = 0f;
            }

            if (noMoveTime >= 5f)
            {
                graveyardBubble.SetActive(true);
                noMoveTime = 0f;
            }

            if (graveyardBubble.activeSelf && Input.GetKeyDown(KeyCode.E))
            {
                graveyardBubble.SetActive(false);
            }
        }

        else if (sceneNum == 3)
        {
            if (bubble[0].activeSelf & Input.GetKeyDown(KeyCode.E))  //Graveyard
            {
                bubble[0].SetActive(false);
                SceneManager.LoadScene("Scene2_Graveyard");
            }
            else if (bubble[1].activeSelf && Input.GetKeyDown(KeyCode.E)) //Forest
            {
                bubble[1].SetActive(false);
                //S3-2s-1 dialogue
            }
            else if (bubble[2].activeSelf && Input.GetKeyDown(KeyCode.E))   //Lunohouse
            {
                bubble[2].SetActive(false);
                //SceneManager.LoadScene("Scene5_lunohouse");
            }
            else if (bubble[3].activeSelf && Input.GetKeyDown(KeyCode.E))   //Library
            {
                bubble[3].SetActive(false);
                //S3-2s-2 dialogue
            }
            else if (bubble[4].activeSelf && Input.GetKeyDown(KeyCode.E))   //Ladder1
            {
                //S3-2s-3 dialogue
            }
            else if (bubble[5].activeSelf && Input.GetKeyDown(KeyCode.E))   //House1
            {
                //S3-2s-4 dialogue
            }
            else if ((bubble[6].activeSelf || bubble[8].activeSelf)
            && Input.GetKeyDown(KeyCode.E))   //Bench1, 2
            {
                //S3-2s-5 dialogue
            }
            else if (bubble[7].activeSelf && Input.GetKeyDown(KeyCode.E))   //Fountain
            {
                //S3-2s-6 dialogue
            }
            else if (bubble[9].activeSelf && Input.GetKeyDown(KeyCode.E))    //House2
            {
                //S3-2s-8 dialogue
            }
            else if (bubble[10].activeSelf && Input.GetKeyDown(KeyCode.E))   //babyBear
            {
                //S3-2s-7 dialogue
            }
            else if (bubble[11].activeSelf && Input.GetKeyDown(KeyCode.E))   //Otaku
            {
                //S3-2s-9~15 dialogue
            }
            else if (bubble[12].activeSelf && Input.GetKeyDown(KeyCode.E))  //Dog
            {
                //S3-2s-16 dialogue
            }

            //no move for 5 secnods
            noMoveTime += Time.deltaTime;

            if (Input.anyKeyDown)
            {
                noMoveTime = 0f;
            }

            if (noMoveTime >= 5f)
            {
                flowerBubble.SetActive(true);
                noMoveTime = 0f;
            }

            if (flowerBubble.activeSelf && Input.GetKeyDown(KeyCode.E))
            {
                flowerBubble.SetActive(false);
            }
        }

        else if (sceneNum == 4)
        {
            if (bubble[0].activeSelf & Input.GetKeyDown(KeyCode.E))  //Graveyard
            {
                bubble[0].SetActive(false);
                SceneManager.LoadScene("Scene2_Graveyard");
            }
            else if (bubble[3].activeSelf && Input.GetKeyDown(KeyCode.E))   //Library
            {
                bubble[3].SetActive(false);
                //sound
            }
            else if (bubble[7].activeSelf && Input.GetKeyDown(KeyCode.E))   //Fountain
            {
                //dialogue
            }
            else if (bubble[11].activeSelf && Input.GetKeyDown(KeyCode.E))   //Otaku
            {

            }
            else if (bubble[12].activeSelf && Input.GetKeyDown(KeyCode.E))  //Dog
            {

            }
        }
        else if (sceneNum == 5)
        {
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

            animator.SetTrigger("FadeOut");
            StartCoroutine(SceneMove());

            animator.SetTrigger("FadeOut");
            StartCoroutine(SceneMove());

            //library enter action
            if (libraryDetail.activeSelf && Input.GetKeyDown(KeyCode.E))
            {
                libraryDetail.SetActive(false);
                noKeyDetail.SetActive(true);
                //화면 중앙 하단에 ‘Q 닫기’ 안내 메시지 출력. 5초간 노출 후 사라짐. 
            }

            if (noKeyDetail.activeSelf && Input.GetKeyDown(KeyCode.Q))
            {
                animator = noKeyDetail.GetComponent<Animator>();
                animator.SetTrigger("PressE");
                StartCoroutine(DetailDisappear());
            }
        }
        else if(sceneNum == 7)
        {
            if (bubble[13].activeSelf && Input.GetKeyDown(KeyCode.E))  //Dog
            {

            }
        }
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

    IEnumerator SceneFadeIn()
    {
        player.GetComponent<Move>().enabled = false;
        yield return new WaitForSeconds(1.0f);
        player.GetComponent<Move>().enabled = true;
        blackScreen.SetActive(false);
    }
}
