using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class LunoHouseManager : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    /*
    [SerializeField]
    Move move;
    */

    //firstPlay
    public bool firstPlay;

    [SerializeField]
    GameObject graveyardBubble;

    //dialogues
    public GameObject S2_1s;
    public GameObject S3_3s;
    public GameObject dayhouse;
    public DialogueManager dialogueManager;
    public bool graveyardDialogue; //S2-1s-1, S2-1s-2

    //interactions
    public GameObject[] Bubble_1F;
    public GameObject[] Bubble_2F;

    //scene
    public int sceneNum;

    [SerializeField]
    PlayableDirector[] director;

    void Start()
    {
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
    }

    void Update()
    {
        if(sceneNum == 2)
        {
            //S2-1s-1, S2-1s-2 done
            if (graveyardDialogue && dialogueManager.GetDone())
            {
                graveyardBubble.SetActive(true);
                graveyardDialogue = false;
            }
            else if (graveyardBubble.activeSelf && Input.GetKeyDown(KeyCode.E))
            {
                graveyardBubble.SetActive(false);
                if(firstPlay)
                {
                    director[1].Play();
                }
            }

            //2F interactions
            //Ladder_2F
            if(Bubble_2F[1].activeSelf && Input.GetKeyDown(KeyCode.E))
            {
                Bubble_2F[1].SetActive(false);

                player.GetComponent<Move>().ladderMode = true;
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
}
