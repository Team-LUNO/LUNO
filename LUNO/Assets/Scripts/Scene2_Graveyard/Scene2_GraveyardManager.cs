using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene2_GraveyardManager : MonoBehaviour
{
    [SerializeField]
    private GameObject blackScreen;

    public GameObject[] interactionObjects;

    Animator screenAnim;

    private int sceneNum = 2;

    public int GetSceneNum()
    {
        return sceneNum;
    }

    void Start()
    {
        screenAnim = blackScreen.GetComponent<Animator>();
    }

    void Update()
    {
        if (interactionObjects[0].transform.GetChild(0).gameObject.activeSelf && Input.GetKeyDown(KeyCode.E))    //DirectorCemetery
        {
            interactionObjects[0].transform.GetChild(0).gameObject.SetActive(false);
            if(sceneNum == 2)
            {
                interactionObjects[0].transform.GetChild(1).GetComponent<DialogueManager>().StartDialogue();
                sceneNum = 3;
            }
            else if(sceneNum == 3)
            {
                if (interactionObjects[0].transform.GetChild(2).GetComponent<DialogueManager>().GetDone())
                {
                    interactionObjects[0].transform.GetChild(2).GetComponent<DialogueManager>().ResetOrder();
                }
                interactionObjects[0].transform.GetChild(2).GetComponent<DialogueManager>().StartDialogue();
            }
        }
        else if(interactionObjects[1].transform.GetChild(0).gameObject.activeSelf && Input.GetKeyDown(KeyCode.E))    //Cemetery1
        {
            interactionObjects[1].transform.GetChild(0).gameObject.SetActive(false);
            if (sceneNum == 2)
            {
                if (interactionObjects[1].transform.GetChild(1).GetComponent<DialogueManager>().GetDone())
                {
                    interactionObjects[1].transform.GetChild(1).GetComponent<DialogueManager>().ResetOrder();
                }
                interactionObjects[1].transform.GetChild(1).GetComponent<DialogueManager>().StartDialogue();
            }
            else if (sceneNum == 3)
            {
                if (interactionObjects[1].transform.GetChild(2).GetComponent<DialogueManager>().GetDone())
                {
                    interactionObjects[1].transform.GetChild(2).GetComponent<DialogueManager>().ResetOrder();
                }
                interactionObjects[1].transform.GetChild(2).GetComponent<DialogueManager>().StartDialogue();
            }
            gameObject.GetComponent<CemeteryDialogueCount>().IncreaseCount();
        }
        else if (interactionObjects[2].transform.GetChild(0).gameObject.activeSelf && Input.GetKeyDown(KeyCode.E))    //Cemetery2
        {
            interactionObjects[2].transform.GetChild(0).gameObject.SetActive(false);
            if (sceneNum == 2)
            {
                if (interactionObjects[2].transform.GetChild(1).GetComponent<DialogueManager>().GetDone())
                {
                    interactionObjects[2].transform.GetChild(1).GetComponent<DialogueManager>().ResetOrder();
                }
                interactionObjects[2].transform.GetChild(1).GetComponent<DialogueManager>().StartDialogue();
            }
            else if (sceneNum == 3)
            {
                if (interactionObjects[2].transform.GetChild(2).GetComponent<DialogueManager>().GetDone())
                {
                    interactionObjects[2].transform.GetChild(2).GetComponent<DialogueManager>().ResetOrder();
                }
                interactionObjects[2].transform.GetChild(2).GetComponent<DialogueManager>().StartDialogue();
            }
            gameObject.GetComponent<CemeteryDialogueCount>().IncreaseCount();
        }
        else if (interactionObjects[3].transform.GetChild(0).gameObject.activeSelf && Input.GetKeyDown(KeyCode.E))    //Cemetery3
        {
            interactionObjects[3].transform.GetChild(0).gameObject.SetActive(false);
            if (sceneNum == 2)
            {
                if (interactionObjects[3].transform.GetChild(1).GetComponent<DialogueManager>().GetDone())
                {
                    interactionObjects[3].transform.GetChild(1).GetComponent<DialogueManager>().ResetOrder();
                }
                interactionObjects[3].transform.GetChild(1).GetComponent<DialogueManager>().StartDialogue();
            }
            else if (sceneNum == 3)
            {
                if (interactionObjects[3].transform.GetChild(2).GetComponent<DialogueManager>().GetDone())
                {
                    interactionObjects[3].transform.GetChild(2).GetComponent<DialogueManager>().ResetOrder();
                }
                interactionObjects[3].transform.GetChild(2).GetComponent<DialogueManager>().StartDialogue();
            }
            gameObject.GetComponent<CemeteryDialogueCount>().IncreaseCount();
        }
        else if (interactionObjects[4].transform.GetChild(0).gameObject.activeSelf && Input.GetKeyDown(KeyCode.E))    //Cemetery4
        {
            interactionObjects[4].transform.GetChild(0).gameObject.SetActive(false);
            if (sceneNum == 2)
            {
                if (interactionObjects[4].transform.GetChild(1).GetComponent<DialogueManager>().GetDone())
                {
                    interactionObjects[4].transform.GetChild(1).GetComponent<DialogueManager>().ResetOrder();
                }
                interactionObjects[4].transform.GetChild(1).GetComponent<DialogueManager>().StartDialogue();
            }
            else if (sceneNum == 3)
            {
                if (interactionObjects[4].transform.GetChild(2).GetComponent<DialogueManager>().GetDone())
                {
                    interactionObjects[4].transform.GetChild(2).GetComponent<DialogueManager>().ResetOrder();
                }
                interactionObjects[4].transform.GetChild(2).GetComponent<DialogueManager>().StartDialogue();
            }
        }
        else if (interactionObjects[5].transform.GetChild(0).gameObject.activeSelf && Input.GetKeyDown(KeyCode.E))    //Cemetery5
        {
            interactionObjects[5].transform.GetChild(0).gameObject.SetActive(false);
            if (sceneNum == 2)
            {
                if (interactionObjects[5].transform.GetChild(1).GetComponent<DialogueManager>().GetDone())
                {
                    interactionObjects[5].transform.GetChild(1).GetComponent<DialogueManager>().ResetOrder();
                }
                interactionObjects[5].transform.GetChild(1).GetComponent<DialogueManager>().StartDialogue();
            }
            else if (sceneNum == 3)
            {
                if (interactionObjects[5].transform.GetChild(2).GetComponent<DialogueManager>().GetDone())
                {
                    interactionObjects[5].transform.GetChild(2).GetComponent<DialogueManager>().ResetOrder();
                }
                interactionObjects[5].transform.GetChild(2).GetComponent<DialogueManager>().StartDialogue();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        screenAnim.SetTrigger("FadeOut");
        StartCoroutine(SceneMoveDelay());
    }

    IEnumerator SceneMoveDelay()
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene("Scene3_Square");
    }
}
