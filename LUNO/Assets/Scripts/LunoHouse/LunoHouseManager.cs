using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunoHouseManager : MonoBehaviour
{
    [SerializeField]
    bool firstPlay;

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
        if(firstDialogue)
        {

        }
    }
}
