using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunoHouseFirstPlay : MonoBehaviour
{
    [SerializeField]
    LunoHouseManager lunoHouseManager;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void GraveyardDialogue()
    {
        lunoHouseManager.dialogueManager.StartDialogue();
        lunoHouseManager.graveyardDialogue = true;
    }
}
