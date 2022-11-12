using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S3_2s_16_2_Selection : SelectionBalloon
{
    DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
