using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainSelection : SelectionBalloon
{
    [SerializeField]
    DialogueManager dialogueManager;

    [SerializeField]
    DialogueManager nextDialogue;

    void Start()
    {

    }

    void Update()
    {

    }

    public override void First()
    {
        if (nextDialogue.GetDone())
            nextDialogue.ResetOrder();
        nextDialogue.StartDialogue();
    }

    public override void Second()
    {
        dialogueManager.IncreaseOrder();
    }
}
