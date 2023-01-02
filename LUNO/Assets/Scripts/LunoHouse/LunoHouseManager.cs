using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class LunoHouseManager : MonoBehaviour
{

    //firstPlay
    [SerializeField]
    bool firstPlay;

    [SerializeField]
    GameObject graveyardBubble;

    [SerializeField]
    PlayableDirector director;

    //dialogues
    public GameObject S2_1s;
    public GameObject S3_3s;
    public GameObject dayhouse;
    DialogueManager dialogueManager;
    bool firstDialogue;

    void Start()
    {
        if(firstPlay)
        {
            dialogueManager 
                = S2_1s.transform.GetChild(1).GetComponent<DialogueManager>();
            dialogueManager.StartDialogue();
        }
        firstDialogue = true;
    }

    void Update()
    {
        if(firstDialogue && dialogueManager.GetDone())
        {
            graveyardBubble.SetActive(true);
            firstDialogue = false;
        }

        if(graveyardBubble.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            graveyardBubble.SetActive(false);
            director.Play();
        }
    }
}
