using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunoHouseFirstPlay : MonoBehaviour
{
    [SerializeField]
    LunoHouseManager lunoHouseManager;

    [SerializeField]
    DialogueManager dialogueManager;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void GraveyardDialogue()
    {
        dialogueManager.StartDialogue();
        lunoHouseManager.graveyardDialogue = true;
    }
}
