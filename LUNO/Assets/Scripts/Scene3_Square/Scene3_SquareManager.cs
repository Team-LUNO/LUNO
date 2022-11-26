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
    private Move move;

    [SerializeField]
    private Vector3[] startPosition;

    [SerializeField]
    private bool firstPlay;

    [SerializeField]
    private GameObject oldDog;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private GameObject mainCamera;

    [SerializeField]
    private GameObject scene7Camera;

    [SerializeField]
    private GameObject bound2;

    CameraController cameraController;

    public GameObject[] bubble;
    public GameObject[] characterBubble;
    public GameObject[] item;
    private float noMoveTime = 0f;

    [SerializeField]
    private GameObject graveyardBubble;

    [SerializeField]
    private GameObject flowerBubble;

    private int otakuDialogue = 19;
    private bool oldDogFirst = true;

    [SerializeField]
    private Vector3 movePosition;

    [SerializeField]
    private Animator lWalk;

    //library
    [SerializeField]
    private GameObject libraryDetail;

    [SerializeField]
    private GameObject noKeyDetail;

    [SerializeField]
    Vector3 libraryPosition;

    private bool libraryOpen;

    //dialogue
    public DialogueManager[] dialogueManager;

    //scene
    public GameObject blackScreen;

    void Start()
    {
        cameraController = cam.GetComponent<CameraController>();

        if (sceneNum == 2 && firstPlay)
        {
            player.transform.position = startPosition[0];   //LunoHouse
            director[0].Play();
            firstPlay = false;
            //sound: ambience_village
        }
        else if (sceneNum == 2 && !firstPlay)
        {
            player.transform.position = startPosition[0];   //LunoHouse
            director[1].Play();
        }
        else if (sceneNum == 3)
        {
            director[1].Play();
            player.transform.position = startPosition[1];   //Graveyard or LunoHouse
        }
        else if(sceneNum == 4)
        {
            player.transform.position = startPosition[0];   //??
            director[1].Play();
        }
        else if(sceneNum == 5)
        {
            player.transform.position = startPosition[1];   //Graveyard
            director[1].Play();
            oldDog.SetActive(true);
        }
        else if(sceneNum == 7)
        {
            //Camera Fixed
            scene7Camera.SetActive(true);
            mainCamera.SetActive(false);
            bound2.SetActive(true);

            player.transform.position = startPosition[2];   //Library
            director[1].Play();
            oldDog.SetActive(true);
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
                //sound: door_iron
            }
            else if (bubble[1].activeSelf && Input.GetKeyDown(KeyCode.E)) //Forest
            {
                bubble[1].SetActive(false);
                //S2-2s-1
                if(dialogueManager[0].GetDone())
                    dialogueManager[0].ResetOrder();
                dialogueManager[0].StartDialogue();
            }
            else if (bubble[2].activeSelf && Input.GetKeyDown(KeyCode.E))   //Lunohouse
            {
                bubble[2].SetActive(false);
                //SceneManager.LoadScene("Scene5_lunohouse");
            }
            else if (bubble[3].activeSelf && Input.GetKeyDown(KeyCode.E))   //Library
            {
                bubble[3].SetActive(false);
                //S2-2s-2
                if (dialogueManager[1].GetDone())
                    dialogueManager[1].ResetOrder();
                dialogueManager[1].StartDialogue();
                //sound: door_unlock
            }
            else if (characterBubble[3].activeSelf && Input.GetKeyDown(KeyCode.E))   //Cow
            {
                characterBubble[3].SetActive(false);
                //S2-2s-3
                if (dialogueManager[2].GetDone())
                    dialogueManager[2].ResetOrder();
                dialogueManager[2].StartDialogue();
            }
            else if (characterBubble[1].activeSelf && Input.GetKeyDown(KeyCode.E))   //Adult
            {
                characterBubble[1].SetActive(false);
                //S2-2s-5
                if (dialogueManager[3].GetDone())
                    dialogueManager[3].ResetOrder();
                dialogueManager[3].StartDialogue();
            }
            else if (bubble[7].activeSelf && Input.GetKeyDown(KeyCode.E))   //Fountain
            {
                bubble[7].SetActive(false);
                //S2-2s-7
                if (dialogueManager[6].GetDone())
                    dialogueManager[6].ResetOrder();
                dialogueManager[6].StartDialogue();
            }
            else if (bubble[8].activeSelf && Input.GetKeyDown(KeyCode.E))   //BenchR
            {
                bubble[8].SetActive(false);
                //sound sitdown
                //S2-2s-6
                if (dialogueManager[5].GetDone())
                    dialogueManager[5].ResetOrder();
                dialogueManager[5].StartDialogue();
                //graveyardBubble
            }
            else if (bubble[9].activeSelf && Input.GetKeyDown(KeyCode.E))   //VillageNotice
            {
                bubble[9].SetActive(false);
                //Image
            }
            else if(bubble[10].activeSelf && Input.GetKeyDown(KeyCode.E))   //VillageGraffiti
            {
                bubble[10].SetActive(false);
                //Image
            }
            else if (characterBubble[2].activeSelf && Input.GetKeyDown(KeyCode.E))   //Bear
            {
                characterBubble[2].SetActive(false);
                StartCoroutine(Scene2Bear());
                //dialogue S2-2s-8

            }
            else if (characterBubble[3].activeSelf && Input.GetKeyDown(KeyCode.E))   //Teenager
            {
                characterBubble[3].SetActive(false);
                //S2-2s-12
            }
            else if (characterBubble[4].activeSelf && Input.GetKeyDown(KeyCode.E))   //Otaku
            {
                characterBubble[4].SetActive(false);
                //S2-2s-10
                if (dialogueManager[9].GetDone())
                    dialogueManager[9].ResetOrder();
                dialogueManager[9].StartDialogue();
            }
            else if (characterBubble[5].activeSelf && Input.GetKeyDown(KeyCode.E))  //Dog
            {
                characterBubble[5].SetActive(false);
                //S2-2s-11
                if (dialogueManager[10].GetDone())
                    dialogueManager[10].ResetOrder();
                dialogueManager[10].StartDialogue();
            }

            //no move for 5 secnods
            noMoveTime += Time.deltaTime;

            if (Input.anyKeyDown || Input.anyKey)
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
                //S3-2s-1
                if (dialogueManager[11].GetDone())
                    dialogueManager[11].ResetOrder();
                dialogueManager[11].StartDialogue();
            }
            else if (bubble[2].activeSelf && Input.GetKeyDown(KeyCode.E))   //Lunohouse
            {
                bubble[2].SetActive(false);
                //SceneManager.LoadScene("Scene5_lunohouse");
            }
            else if (bubble[3].activeSelf && Input.GetKeyDown(KeyCode.E))   //Library
            {
                bubble[3].SetActive(false);
                //S3-2s-2
                if (dialogueManager[12].GetDone())
                    dialogueManager[12].ResetOrder();
                dialogueManager[12].StartDialogue();
                //sound: door_unlock
            }
            else if (bubble[4].activeSelf && Input.GetKeyDown(KeyCode.E))   //Ladder1
            {
                bubble[4].SetActive(false);
                //S3-2s-3
                if (dialogueManager[13].GetDone())
                    dialogueManager[13].ResetOrder();
                dialogueManager[13].StartDialogue();
            }
            else if (bubble[5].activeSelf && Input.GetKeyDown(KeyCode.E))   //House1
            {
                bubble[5].SetActive(false);
                //S3-2s-4
                if (dialogueManager[14].GetDone())
                    dialogueManager[14].ResetOrder();
                dialogueManager[14].StartDialogue();
            }
            else if ((bubble[6].activeSelf || bubble[8].activeSelf)
            && Input.GetKeyDown(KeyCode.E))   //Bench1, 2
            {
                bubble[6].SetActive(false);
                bubble[8].SetActive(false);
                //S3-2s-5
                if (dialogueManager[15].GetDone())
                    dialogueManager[15].ResetOrder();
                dialogueManager[15].StartDialogue();
            }
            else if (bubble[7].activeSelf && Input.GetKeyDown(KeyCode.E))   //Fountain
            {
                bubble[7].SetActive(false);
                //S3-2s-6
                if (dialogueManager[16].GetDone())
                    dialogueManager[16].ResetOrder();
                dialogueManager[16].StartDialogue();
            }
            else if (bubble[9].activeSelf && Input.GetKeyDown(KeyCode.E))    //House2
            {
                bubble[9].SetActive(false);
                //S3-2s-8
                if (dialogueManager[18].GetDone())
                    dialogueManager[18].ResetOrder();
                dialogueManager[18].StartDialogue();
            }
            else if (bubble[10].activeSelf && Input.GetKeyDown(KeyCode.E))   //babyBear
            {
                bubble[10].SetActive(false);
                //S3-2s-7
                if (dialogueManager[17].GetDone())
                    dialogueManager[17].ResetOrder();
                dialogueManager[17].StartDialogue();
            }
            else if (bubble[11].activeSelf && Input.GetKeyDown(KeyCode.E))   //Otaku
            {
                bubble[11].SetActive(false);
                //S3-2s-9~15 dialogue
                dialogueManager[otakuDialogue].StartDialogue();
                if (otakuDialogue != 25)
                {
                    otakuDialogue++;
                }
                else
                {
                    if (dialogueManager[25].GetDone())
                        dialogueManager[25].ResetOrder();
                }
            }
            else if (bubble[12].activeSelf && Input.GetKeyDown(KeyCode.E))  //Dog
            {
                bubble[12].SetActive(false);
                //S3-2s-16
                if (dialogueManager[26].GetDone())
                    dialogueManager[26].ResetOrder();
                dialogueManager[26].StartDialogue();
            }

            //no move for 5 secnods
            noMoveTime += Time.deltaTime;

            if (Input.anyKeyDown || Input.anyKey)
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
                //sound; door_iron
            }
            else if (bubble[3].activeSelf && Input.GetKeyDown(KeyCode.E))   //Library
            {
                bubble[3].SetActive(false);
                //sound: door_unlock
            }
            else if (bubble[7].activeSelf && Input.GetKeyDown(KeyCode.E))   //Fountain
            {
                bubble[7].SetActive(false);
                //S4-1s-1
                if (dialogueManager[27].GetDone())
                    dialogueManager[27].ResetOrder();
                dialogueManager[27].StartDialogue();
            }
            else if (bubble[11].activeSelf && Input.GetKeyDown(KeyCode.E))   //Otaku
            {
                bubble[11].SetActive(false);
                //S4-1s-3
                if (dialogueManager[29].GetDone())
                    dialogueManager[29].ResetOrder();
                dialogueManager[29].StartDialogue();
            }
            else if (bubble[12].activeSelf && Input.GetKeyDown(KeyCode.E))  //Dog
            {
                bubble[12].SetActive(false);
                //S4-1s-4
                if (dialogueManager[30].GetDone())
                    dialogueManager[30].ResetOrder();
                dialogueManager[30].StartDialogue();
            }
        }
        else if (sceneNum == 5)
        {
            if(bubble[3].activeSelf && Input.GetKeyDown(KeyCode.E))   //Library
            {
                bubble[3].SetActive(false);
                if (libraryOpen)
                {
                    StartCoroutine(EnterLibrary());
                }
                else if(item[0].activeSelf)
                {
                    item[0].SetActive(false);
                    libraryOpen = true;
                    StartCoroutine(EnterLibrary());
                }
                else if(!item[0].activeSelf)
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
                }
            }
            else if (libraryDetail.activeSelf && Input.GetKeyDown(KeyCode.E))
            {
                libraryDetail.SetActive(false);
                noKeyDetail.SetActive(true);
                StartCoroutine(DetailDisappear());
            }
            else if (bubble[7].activeSelf && Input.GetKeyDown(KeyCode.E))   //Fountain
            {
                bubble[7].SetActive(false);
                //S5-2s-3
                if (dialogueManager[33].GetDone())
                    dialogueManager[33].ResetOrder();
                dialogueManager[33].StartDialogue();
            }
            else if (bubble[11].activeSelf && Input.GetKeyDown(KeyCode.E))   //Otaku
            {
                bubble[11].SetActive(false);
                //S5-2s-4
                if (dialogueManager[34].GetDone())
                    dialogueManager[34].ResetOrder();
                dialogueManager[34].StartDialogue();
            }
            else if (bubble[12].activeSelf && Input.GetKeyDown(KeyCode.E))  //Dog
            {
                bubble[12].SetActive(false);
                //S5-2s-5
                if (dialogueManager[35].GetDone())
                    dialogueManager[35].ResetOrder();
                dialogueManager[35].StartDialogue();
            }
            else if (bubble[13].activeSelf && Input.GetKeyDown(KeyCode.E))  //Old Dog
            {
                bubble[13].SetActive(false);
                if (oldDogFirst)
                {
                    //S5-2s-1
                    dialogueManager[31].StartDialogue();
                }
                else
                {
                    //S5-2s-2
                    if (dialogueManager[32].GetDone())
                        dialogueManager[32].ResetOrder();
                    dialogueManager[32].StartDialogue();
                }
            }
        }
        else if(sceneNum == 7)
        {
            //dialogues
        }
    }

    IEnumerator DetailDisappear()
    {
        yield return new WaitForSecondsRealtime(1f);
        noKeyDetail.SetActive(false);
        item[0].SetActive(true);
        player.GetComponent<Move>().enabled = true;
    }

    IEnumerator EnterLibrary()
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene("Scene4_Library");
    }

    IEnumerator Scene2Bear()
    {
        player.GetComponent<Move>().enabled = false;
        Animator anim = player.GetComponent<Animator>();
        anim.runtimeAnimatorController 
            = lWalk.runtimeAnimatorController;
        anim.SetBool("IsWalk", true);

        Vector3 dir = (movePosition - player.transform.position).normalized;
        float speed = 1.2f;
        float distance = Vector3.Distance(movePosition, player.transform.position);

        while (distance > 0.1f)
        {
            player.transform.position 
                    = Vector3.MoveTowards(player.transform.position, movePosition, speed*Time.deltaTime);
            distance = Vector3.Distance(movePosition, player.transform.position);
            yield return new WaitForFixedUpdate();
        }
        player.GetComponent<Move>().enabled = true;
        yield return new WaitForSeconds(1f);
        if (dialogueManager[7].GetDone())
            dialogueManager[7].ResetOrder();
        dialogueManager[7].StartDialogue();
    }
}
