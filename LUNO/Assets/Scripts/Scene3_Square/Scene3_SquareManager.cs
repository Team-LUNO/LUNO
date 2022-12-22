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
    public GameObject keyItem;
    private float noMoveTime = 0f;

    [SerializeField]
    private GameObject graveyardBubble;

    [SerializeField]
    private GameObject flowerBubble;

    private int otakuDialogue = 9;
    private bool oldDogFirst = true;

    [SerializeField]
    private Vector3 movePosition;

    [SerializeField]
    private Animator lWalk;

    [SerializeField]
    private GameObject villageNotice;

    [SerializeField]
    private GameObject villageGraffiti;

    //library
    [SerializeField]
    private GameObject libraryDetail;

    [SerializeField]
    private GameObject noKeyDetail;

    [SerializeField]
    Vector3 libraryPosition;

    private bool libraryOpen;

    //dialogues
    DialogueManager dialogueManager;
    public GameObject S2_2s;
    public GameObject S3_2s;
    public GameObject S4_1s;
    public GameObject S5_2s;
    public GameObject S7_1s;

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
                RepeatableDialogue(S2_2s, 1);
            }
            else if (bubble[2].activeSelf && Input.GetKeyDown(KeyCode.E))   //Lunohouse
            {
                bubble[2].SetActive(false);
                //SceneManager.LoadScene("Scene5_lunohouse");
            }
            else if (bubble[3].activeSelf && Input.GetKeyDown(KeyCode.E))   //Library
            {
                bubble[3].SetActive(false);
                RepeatableDialogue(S2_2s, 2);
                //sound: door_unlock
            }
            else if (characterBubble[4].activeSelf && Input.GetKeyDown(KeyCode.E))   //Cow
            {
                characterBubble[4].SetActive(false);
                RepeatableDialogue(S2_2s, 3);
            }
            else if (characterBubble[1].activeSelf && Input.GetKeyDown(KeyCode.E))   //Adult
            {
                characterBubble[1].SetActive(false);
                RepeatableDialogue(S2_2s, 5);
            }
            else if (bubble[7].activeSelf && Input.GetKeyDown(KeyCode.E))   //Fountain
            {
                bubble[7].SetActive(false);
                RepeatableDialogue(S2_2s, 7);
            }
            else if (bubble[8].activeSelf && Input.GetKeyDown(KeyCode.E))   //BenchR
            {
                bubble[8].SetActive(false);
                //sound sitdown
                RepeatableDialogue(S2_2s, 6);
                //graveyardBubble
                //sound: speechbigin
            }
            else if (characterBubble[2].activeSelf && Input.GetKeyDown(KeyCode.E))   //Bear
            {
                characterBubble[2].SetActive(false);
                StartCoroutine(Scene2Bear());
            }
            else if (bubble[9].activeSelf && Input.GetKeyDown(KeyCode.E))   //VillageNotice
            {
                bubble[9].SetActive(false);
                villageNotice.SetActive(true);
            }
            else if (characterBubble[3].activeSelf && Input.GetKeyDown(KeyCode.E))   //Teenager
            {
                characterBubble[3].SetActive(false);
                RepeatableDialogue(S2_2s, 12);
            }
            else if(bubble[10].activeSelf && Input.GetKeyDown(KeyCode.E))   //VillageGraffiti
            {
                bubble[10].SetActive(false);
                villageGraffiti.SetActive(true);
            }
            else if (characterBubble[4].activeSelf && Input.GetKeyDown(KeyCode.E))   //Otaku
            {
                characterBubble[4].SetActive(false);
                RepeatableDialogue(S2_2s, 10);
            }
            else if (characterBubble[5].activeSelf && Input.GetKeyDown(KeyCode.E))  //Dog
            {
                characterBubble[5].SetActive(false);
                RepeatableDialogue(S2_2s, 11);
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
                RepeatableDialogue(S3_2s, 1);
            }
            else if (bubble[2].activeSelf && Input.GetKeyDown(KeyCode.E))   //Lunohouse
            {
                bubble[2].SetActive(false);
                //SceneManager.LoadScene("Scene5_lunohouse");
                //Bgm fade out
            }
            else if (bubble[3].activeSelf && Input.GetKeyDown(KeyCode.E))   //Library
            {
                bubble[3].SetActive(false);
                RepeatableDialogue(S3_2s, 2);
                //sound: door_unlock
            }
            else if (characterBubble[4].activeSelf && Input.GetKeyDown(KeyCode.E))   //Cow
            {
                characterBubble[4].SetActive(false);
                RepeatableDialogue(S3_2s, 3);
            }
            else if (characterBubble[1].activeSelf && Input.GetKeyDown(KeyCode.E))   //Adult
            {
                characterBubble[1].SetActive(false);
                RepeatableDialogue(S3_2s, 17);
            }
            else if (bubble[8].activeSelf && Input.GetKeyDown(KeyCode.E))   //BenchR
            {
                bubble[8].SetActive(false);
                RepeatableDialogue(S3_2s, 5);
                //flowerBubble
            }
            else if (bubble[7].activeSelf && Input.GetKeyDown(KeyCode.E))   //Fountain
            {
                bubble[7].SetActive(false);
                RepeatableDialogue(S3_2s, 6);
            }
            else if (bubble[10].activeSelf && Input.GetKeyDown(KeyCode.E))   //Bear
            {
                bubble[10].SetActive(false);
                RepeatableDialogue(S3_2s, 7);
            }
            else if (bubble[9].activeSelf && Input.GetKeyDown(KeyCode.E))   //VillageNotice
            {
                bubble[9].SetActive(false);
                villageNotice.SetActive(true);
            }
            else if (characterBubble[3].activeSelf && Input.GetKeyDown(KeyCode.E))   //Teenager
            {
                characterBubble[3].SetActive(false);
                RepeatableDialogue(S3_2s, 18);
            }
            else if (bubble[10].activeSelf && Input.GetKeyDown(KeyCode.E))   //VillageGraffiti
            {
                bubble[10].SetActive(false);
                villageGraffiti.SetActive(true);
            }
            else if (bubble[11].activeSelf && Input.GetKeyDown(KeyCode.E))   //Otaku
            {
                bubble[11].SetActive(false);
                if (otakuDialogue >= 9 || otakuDialogue < 15)
                {
                    dialogueManager 
                        = S3_2s.transform.GetChild(otakuDialogue).GetComponent<DialogueManager>();
                    dialogueManager.StartDialogue();
                    otakuDialogue++;
                }
                else
                {
                    RepeatableDialogue(S3_2s, 15);
                }
            }
            else if (bubble[12].activeSelf && Input.GetKeyDown(KeyCode.E))  //Dog
            {
                bubble[12].SetActive(false);
                RepeatableDialogue(S3_2s, 16);
                //scene3 -> 4
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
                RepeatableDialogue(S4_1s, 1);
            }
            else if (bubble[2].activeSelf && Input.GetKeyDown(KeyCode.E))   //Lunohouse
            {
                bubble[2].SetActive(false);
                //SceneManager.LoadScene("Scene5_lunohouse");
                //Bgm fade out
            }
            else if (bubble[11].activeSelf && Input.GetKeyDown(KeyCode.E))   //Otaku
            {
                bubble[11].SetActive(false);
                RepeatableDialogue(S4_1s, 3);
            }
            else if (bubble[12].activeSelf && Input.GetKeyDown(KeyCode.E))  //Dog
            {
                bubble[12].SetActive(false);
                RepeatableDialogue(S4_1s, 4);
            }
            else if (bubble[9].activeSelf && Input.GetKeyDown(KeyCode.E))   //VillageNotice
            {
                bubble[9].SetActive(false);
                villageNotice.SetActive(true);
            }
            else if (characterBubble[3].activeSelf && Input.GetKeyDown(KeyCode.E))   //Teenager
            {
                characterBubble[3].SetActive(false);
                //RepeatableDialogue(S4_1s, );
            }
            else if (bubble[10].activeSelf && Input.GetKeyDown(KeyCode.E))   //VillageGraffiti
            {
                bubble[10].SetActive(false);
                villageGraffiti.SetActive(true);
            }
            else if (bubble[10].activeSelf && Input.GetKeyDown(KeyCode.E))   //Bear
            {
                bubble[10].SetActive(false);
                //RepeatableDialogue(S4_1s, 2);
            }
            else if (characterBubble[4].activeSelf && Input.GetKeyDown(KeyCode.E))   //Cow
            {
                characterBubble[4].SetActive(false);
                //RepeatableDialogue(S4_1s, );
            }
            else if (characterBubble[1].activeSelf && Input.GetKeyDown(KeyCode.E))   //Adult
            {
                characterBubble[1].SetActive(false);
                //RepeatableDialogue(S4_1s, );
            }
            else if (bubble[8].activeSelf && Input.GetKeyDown(KeyCode.E))   //BenchR
            {
                bubble[8].SetActive(false);
                RepeatableDialogue(S4_1s, 5);
                //flowerBubble
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
        else if (sceneNum == 5)
        {
            if (bubble[13].activeSelf && Input.GetKeyDown(KeyCode.E))  //Old Dog
            {
                bubble[13].SetActive(false);
                if (oldDogFirst)
                {
                    dialogueManager
                        = S5_2s.transform.GetChild(1).GetComponent<DialogueManager>();
                    dialogueManager.StartDialogue();
                }
                else
                {
                    RepeatableDialogue(S5_2s, 2);
                }
            }
            else if (bubble[0].activeSelf & Input.GetKeyDown(KeyCode.E))  //Graveyard
            {
                bubble[0].SetActive(false);
                SceneManager.LoadScene("Scene2_Graveyard");
                //sound; door_iron
            }
            else if (bubble[2].activeSelf && Input.GetKeyDown(KeyCode.E))   //Lunohouse
            {
                bubble[2].SetActive(false);
                //SceneManager.LoadScene("Scene5_lunohouse");
                //Bgm fade out
            }
            else if (characterBubble[4].activeSelf && Input.GetKeyDown(KeyCode.E))   //Cow
            {
                characterBubble[4].SetActive(false);
                RepeatableDialogue(S5_2s, 6);
            }
            else if (bubble[7].activeSelf && Input.GetKeyDown(KeyCode.E))   //Fountain
            {
                bubble[7].SetActive(false);
                RepeatableDialogue(S5_2s, 3);
            }
            else if ((bubble[6].activeSelf || bubble[8].activeSelf) 
                        && Input.GetKeyDown(KeyCode.E))   //BenchL, BenchR
            {
                bubble[6].SetActive(false);
                bubble[8].SetActive(false);
                RepeatableDialogue(S5_2s, 7);
            }
            else if (bubble[9].activeSelf && Input.GetKeyDown(KeyCode.E))   //VillageNotice
            {
                bubble[9].SetActive(false);
                villageNotice.SetActive(true);
            }
            else if (characterBubble[3].activeSelf && Input.GetKeyDown(KeyCode.E))   //Teenager
            {
                characterBubble[3].SetActive(false);
                RepeatableDialogue(S5_2s, 8);
            }
            else if (bubble[10].activeSelf && Input.GetKeyDown(KeyCode.E))   //VillageGraffiti
            {
                bubble[10].SetActive(false);
                villageGraffiti.SetActive(true);
            }
            else if (bubble[11].activeSelf && Input.GetKeyDown(KeyCode.E))   //Otaku
            {
                bubble[11].SetActive(false);
                RepeatableDialogue(S5_2s, 4);
            }
            else if (bubble[12].activeSelf && Input.GetKeyDown(KeyCode.E))  //Dog
            {
                bubble[12].SetActive(false);
                RepeatableDialogue(S5_2s, 5);
            }
            else if (bubble[3].activeSelf && Input.GetKeyDown(KeyCode.E))   //Library
            {
                bubble[3].SetActive(false); 
                if(!libraryOpen && !keyItem.activeSelf)
                {
                    libraryDetail.SetActive(true);
                    //sound: pop_inout

                    player.GetComponent<Move>().enabled = false;
                    //player.transform.position = libraryPosition;

                    //camera move
                    cameraController.targetPosition
                        = new Vector3(cam.transform.position.x + 2.5f, cam.transform.position.y, cam.transform.position.z);
                    cameraController.smoothTime = 0.38f;
                    cameraController.cameraMove = false;
                    cameraController.moveRight = true;
                }
                else if (keyItem.activeSelf)
                {
                    //sound: door_library
                    keyItem.SetActive(false);
                    libraryOpen = true;
                    StartCoroutine(EnterLibrary());
                }
                else if (libraryOpen)
                {
                    StartCoroutine(EnterLibrary());
                }
            }
            else if (libraryDetail.activeSelf && Input.GetKeyDown(KeyCode.E))
            {
                //sound: item_get
                libraryDetail.SetActive(false);
                noKeyDetail.SetActive(true);
                keyItem.SetActive(true);
                StartCoroutine(DetailDisappear());
            }
        }
        else if(sceneNum == 7)
        {
            if (bubble[13].activeSelf && Input.GetKeyDown(KeyCode.E))  //Old Dog
            {
                bubble[13].SetActive(false);
                RepeatableDialogue(S7_1s, 2);
            }
        }

        if (villageNotice.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            villageNotice.SetActive(false);
        }
        else if (villageGraffiti.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            villageGraffiti.SetActive(false);
        }
    }

    IEnumerator DetailDisappear()
    {
        yield return new WaitForSecondsRealtime(1f);
        //sound: pop_inout
        noKeyDetail.SetActive(false);
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
        RepeatableDialogue(S2_2s, 8);
    }

    void RepeatableDialogue(GameObject dialogue, int num)
    {
        dialogueManager 
            = dialogue.transform.GetChild(num).GetComponent<DialogueManager>();
        if (dialogueManager.GetDone())
            dialogueManager.ResetOrder();
        dialogueManager.StartDialogue();
    }
}
