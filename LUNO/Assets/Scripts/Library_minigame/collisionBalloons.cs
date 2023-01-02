using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionBalloons : MonoBehaviour
{
    public DialogueManager dialogue1;
    public DialogueManager dialogue2;
    public S1_03_selection s1;

    public bool isExit=true;
    private int cnt;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("keepsake"))
        {
            if (dialogue1.GetDone())
                dialogue1.ResetOrder();
            dialogue1.StartDialogue();
        }
        else if (collision.CompareTag("bookcart"))
        {
            //Debug.Log("trigger");
            cnt = s1.getCnt();
            Debug.Log(s1.dialogueManagers[cnt].GetDone());
            if (s1.dialogueManagers[cnt].GetDone())     
                dialogue2.ResetOrder();
            dialogue2.StartDialogue();
        }
    }
}
