using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class LunoHouseManager : MonoBehaviour
{
    //player
    [SerializeField]
    GameObject player;

    public CameraController cameraController;
    public CameraController_2F cameraController_2F;

    //firstPlay
    public bool firstPlay;
    public GameObject moveInfo;
    public GameObject ladderInfo;

    //dialogues
    public GameObject S2_1s;
    public GameObject S3_3s;
    public GameObject dayhouse;
    public DialogueManager dialogueManager;
    public bool graveyardDialogue; //for S2-1s-1, S2-1s-2

    [SerializeField]
    GameObject[] imageBubble;

    private float noMoveTime = 0f;

    //interactions
    public GameObject[] Bubble_1F;
    public GameObject[] Bubble_2F;

    //ladder
    public Vector3 ladder1F;
    public Vector3 ladder2F;
    public GameObject ladderCollider;

    [SerializeField]
    Vector3 climb1F;

    [SerializeField]
    Vector3 climb2F;

    [SerializeField]
    Animator climb;

    //scene
    public int sceneNum;

    //Scene Start
    [SerializeField]
    PlayableDirector[] director;

    [SerializeField]
    Vector3[] startPosition;

    void Start()
    {
        cameraController 
            = player.transform.GetChild(0).GetComponent<CameraController>();
        cameraController_2F 
            = player.transform.GetChild(0).GetComponent<CameraController_2F>();

        //First Play
        if(firstPlay)
        {
            dialogueManager
                = S2_1s.transform.GetChild(1).GetComponent<DialogueManager>();
            director[1].Play();
        }
        else
        {
            director[0].Play();
        }

        //Scene Condition
        if(sceneNum == 2)
        {
            cameraController.enabled = false;
            player.transform.position = startPosition[0];
            noMoveTime = -5f;
        }
    }

    void Update()
    {
        if(sceneNum == 2)
        {
            //S2-1s-1, S2-1s-2 done
            if (graveyardDialogue && dialogueManager.GetDone())
            {
                imageBubble[0].SetActive(true);
                imageBubble[1].SetActive(true);
                graveyardDialogue = false;
            }
            else if (imageBubble[1].activeSelf && Input.GetKeyDown(KeyCode.E))
            {
                imageBubble[0].SetActive(false);
                imageBubble[1].SetActive(false);
                if(firstPlay)
                {
                    moveInfo.SetActive(true);
                }
            }

            //2F interactions
            //Ladder_2F
            if(Bubble_2F[1].activeSelf && Input.GetKeyDown(KeyCode.E))
            {
                Bubble_2F[1].SetActive(false);
                LadderOn(ladder2F);
                
            }
            //Bed
            else if (Bubble_2F[2].activeSelf && Input.GetKeyDown(KeyCode.E))
            {
                Bubble_2F[2].SetActive(false);
                RepeatableDialogue(S2_1s, 2);
                graveyardDialogue = true;
            }
            //WaterCup
            else if(Bubble_2F[0].activeSelf && Input.GetKeyDown(KeyCode.E))
            {
                Bubble_2F[0].SetActive(false);
                RepeatableDialogue(S2_1s, 7);
            }

            //1F interations
            //Ladder_1F
            else if(Bubble_1F[4].activeSelf && Input.GetKeyDown(KeyCode.E))
            {
                Bubble_1F[4].SetActive(false);
                LadderOn(ladder1F);
            }
            //Door
            else if (Bubble_1F[6].activeSelf && Input.GetKeyDown(KeyCode.E))
            {
                Bubble_1F[6].SetActive(false);
                //sound: door
                //fade out
                SceneManager.LoadScene("Scene3_Square");
            }
            //Cabine
            else if (Bubble_1F[0].activeSelf && Input.GetKeyDown(KeyCode.E))
            {
                Bubble_1F[0].SetActive(false);
                RepeatableDialogue(S2_1s, 3);
            }
            //Vase
            else if (Bubble_1F[1].activeSelf && Input.GetKeyDown(KeyCode.E))
            {
                Bubble_1F[1].SetActive(false);
                RepeatableDialogue(S2_1s, 4);
            }
            //Picture
            else if (Bubble_1F[3].activeSelf && Input.GetKeyDown(KeyCode.E))
            {
                Bubble_1F[3].SetActive(false);
                RepeatableDialogue(S2_1s, 5);
            }
            //ShoeShelf
            else if (Bubble_1F[5].activeSelf && Input.GetKeyDown(KeyCode.E))
            {
                Bubble_1F[5].SetActive(false);
                RepeatableDialogue(S2_1s, 6);
            }
            else if (Bubble_1F[2].activeSelf && Input.GetKeyDown(KeyCode.E))
            {
                Bubble_1F[2].SetActive(false);
                //sound: volume * 1.4
            }

            //no move for 5 secnods
            noMoveTime += Time.deltaTime;

            if (Input.anyKeyDown || Input.anyKey)
            {
                noMoveTime = 0f;
            }

            if (noMoveTime >= 5f)
            {
                imageBubble[0].SetActive(true);
                imageBubble[1].SetActive(true);
                noMoveTime = 0f;
            }
        }
    }

    void RepeatableDialogue(GameObject dialogue, int num)
    {
        dialogueManager
            = dialogue.transform.GetChild(num).GetComponent<DialogueManager>();
        if (dialogueManager.GetDone())
            dialogueManager.ResetOrder();
        dialogueManager.StartDialogue();
    }

    void LadderOn(Vector3 ladderPosition)
    {
        ladderCollider.SetActive(true);
        player.transform.position = ladderPosition;
        //2F ladder
        if(cameraController_2F.enabled)
        {
            cameraController_2F.enabled = false;
            StartCoroutine(ClimbAutomatically(climb2F));
        }
        //1F ladder
        else
        {
            cameraController.enabled = false;
            StartCoroutine(ClimbAutomatically(climb1F));
        }
    }

    IEnumerator ClimbAutomatically(Vector3 climbPosition)
    {
        player.GetComponent<Move>().enabled = false;
        player.GetComponent<Rigidbody2D>().gravityScale = 0;
        Animator anim = player.GetComponent<Animator>();
        anim.runtimeAnimatorController
            = climb.runtimeAnimatorController;

        float speed = 5f;
        float distance = Vector3.Distance(climbPosition, player.transform.position);

        while (distance > 0.1f)
        {
            player.transform.position
                    = Vector3.MoveTowards(player.transform.position, climbPosition, speed * Time.deltaTime);
            distance = Vector3.Distance(climbPosition, player.transform.position);
            yield return new WaitForFixedUpdate();
        }
        player.GetComponent<Move>().enabled = true;
    }
}
