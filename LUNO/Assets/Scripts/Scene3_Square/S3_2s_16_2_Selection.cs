using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S3_2s_16_2_Selection : SelectionBalloon
{
    [SerializeField]
    private DialogueManager dialogueManager;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public override void First()
    {
        dialogueManager.IncreaseOrder();
    }

    public override void Second()
    {
        dialogueManager.IncreaseOrder();
    }

    public override void Third()
    {
        dialogueManager.IncreaseOrder();
    }
}
