using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S3_2s_16_1_Selection : SelectionBalloon
{
    [SerializeField]
    private Scene3_SquareManager UIManager;

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
        if (UIManager.dialogueManager[36].GetDone())
            UIManager.dialogueManager[36].ResetOrder();
        UIManager.dialogueManager[36].StartDialogue();
        UIManager.dialogueManager[26].IncreaseOrder();
    }

    public override void Second()
    {
        UIManager.dialogueManager[37].StartDialogue();
        UIManager.dialogueManager[26].IncreaseOrder();
    }
}
