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
    private GameObject elder;

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

    //quest condition
    //not doing: -1, doing: 0, finished: 1
    public int quest1;
    public bool libraryOn;
    bool enterLibrary;

    void Start()
    {
        cameraController = cam.GetComponent<CameraController>();
        blackScreenAnim = blackScreen.GetComponent<Animator>();  
        
        if(quest1 == 1 && !enterLibrary)
        {
            elder.SetActive(true);
            libraryOn = true;
        }
    }
    void Update()
    {
        //collider action
        if (bubble[0].activeSelf & Input.GetKeyDown(KeyCode.E))  //graveyard
        {
            bubble[0].SetActive(false);
            SceneManager.LoadScene("Scene2_Graveyard");
        }
        else if ((bubble[1].activeSelf || bubble[2].activeSelf || bubble[3].activeSelf)
            && Input.GetKeyDown(KeyCode.E)) //forest
        {
            bubble[1].SetActive(false);
            bubble[2].SetActive(false);
            bubble[3].SetActive(false);

            int num = Random.Range(1, 10);

            //dialogue test
            //num = 6;
            //num = 10;

            if (num >= 1 && num <= 6)
            {
                dialogueManager[0].StartDialogue();
            }
            else if (num >= 7 && num <= 9)    //fruit
            {
                if (dialogueManager[1].GetDone())
                    dialogueManager[1].ResetOrder();
                dialogueManager[1].StartDialogue();
            }
            else    //coin
            {
                if (dialogueManager[2].GetDone())
                    dialogueManager[2].ResetOrder();
                dialogueManager[2].StartDialogue();

                getItemName = "coin";

                if (!hasItem)
                {
                    getItem();
                }
                else
                {
                    itemDialogue();
                }
            }
        }
        else if (bubble[4].activeSelf && Input.GetKeyDown(KeyCode.E))   //lunohouse
        {
            bubble[4].SetActive(false);
            //SceneManager.LoadScene("Scene5_lunohouse");
        }
        else if (bubble[5].activeSelf && Input.GetKeyDown(KeyCode.E))   //library
        {
            bubble[5].SetActive(false);
            if (!libraryOn)
            {
                if (dialogueManager[3].GetDone())
                    dialogueManager[3].ResetOrder();
                dialogueManager[3].StartDialogue();
            }
            else if (libraryOn && hasItemName != "key")  //get key
            {
                elder.SetActive(false);
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
        }


        else if (bubble[9].activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            bubble[9].SetActive(false);
            if (dialogueManager[10].GetDone())
                dialogueManager[10].ResetOrder();
            dialogueManager[10].StartDialogue();
        }

        else if (bubble[12].activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            bubble[12].SetActive(false);
            if (dialogueManager[9].GetDone())
                dialogueManager[9].ResetOrder();
            dialogueManager[9].StartDialogue();
        }

        else if (bubble[13].activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            bubble[13].SetActive(false);
            if (quest1 == -1 || quest1 == 1)
            {
                if (dialogueManager[15].GetDone())
                    dialogueManager[15].ResetOrder();
                dialogueManager[15].StartDialogue();
            }
            else if (quest1 == 0)
            {
                if (dialogueManager[12].GetDone())
                    dialogueManager[12].ResetOrder();
                dialogueManager[12].StartDialogue();
            }
        }
        else if (bubble[14].activeSelf && Input.GetKeyDown(KeyCode.E))
        {

        }

        if(dialogueManager[1].GetDone())
        {
            dialogueManager[0].ResetOrder();
            getItemName = "fruit";
            if (!hasItem)
            {
                getItem();
            }
            else
            {
                itemDialogue();
            }
        }

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
    }

    public void getItem()
    {
        hasItem = true;
        switch (getItemName)
        {
            case ("fruit"):
                item[0].SetActive(true);
                hasItemName = "fruit";
                break;
            case ("coin"):
                item[1].SetActive(true);
                hasItemName = "coin";
                break;
            case ("key"):
                item[2].SetActive(true);
                hasItemName = "key";
                break;
        }
    }

    void itemDialogue()
    {
        switch(hasItemName)
        {
            case ("fruit"):
                dialogueManager[5].StartDialogue();
                break;
            case ("coin"):
                dialogueManager[6].StartDialogue();
                break;
            case ("key"):
                dialogueManager[7].StartDialogue();
                break;
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

    
}
