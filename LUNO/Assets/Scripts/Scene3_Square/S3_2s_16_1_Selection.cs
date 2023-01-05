using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S3_2s_16_1_Selection : SelectionBalloon
{
    [SerializeField]
    private DialogueManager[] dialogueManager;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public override void First()
    {
        if (dialogueManager[1].GetDone())
            dialogueManager[1].ResetOrder();
        dialogueManager[1].StartDialogue();

        dialogueManager[0].IncreaseOrder();
    }

    public override void Second()
    {
        if (dialogueManager[2].GetDone())
            dialogueManager[2].ResetOrder();
        dialogueManager[2].StartDialogue();

        dialogueManager[0].IncreaseOrder();
    }
}
