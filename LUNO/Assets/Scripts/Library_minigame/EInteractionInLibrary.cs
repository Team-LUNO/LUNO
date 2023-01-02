using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EInteractionInLibrary : MonoBehaviour
{
    public int nowStatus = 0;
    //nowStatus 0: 처음 / 1: 책 들고 있음 / 2: 책 내려놓음 
    public bool[] collisionSwitch;
    // collisionSwitch [0]: keepsake / [1]: bookcart / [2] : vase

    public DialogueManager[] dialogues;
    public S1_03_selection s1;
    private int cnt;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("keepsake"))
        {
            collisionSwitch[0] = true;
        }
        else if (collision.CompareTag("bookcart"))
        {
            collisionSwitch[1] = true;
        }
        else if (collision.CompareTag("vase"))
        {
            collisionSwitch[2] = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("keepsake"))
        {
            collisionSwitch[0] = false;
        }
        else if (collision.CompareTag("bookcart"))
        {
            collisionSwitch[1] = false;

        }else if (collision.CompareTag("vase"))
        {
            collisionSwitch[2] = false;

        }
    }

    void keepsakeBalloons(int i)
    {
        if (dialogues[i].GetDone())
            dialogues[i].ResetOrder();
        dialogues[i].StartDialogue();
    }

    void bookcartBalloons(int i)
    {

        //cnt = s1.getCnt();
        //Debug.Log(cnt);
        //Debug.Log(s1.dialogueManagers[cnt].GetDone());
        //if (s1.dialogueManagers[cnt].GetDone())
        //dialogues[i].ResetOrder();
        if (dialogues[i].GetDone())
            dialogues[i].ResetOrder();
        dialogues[i].StartDialogue();
    }

    void vaseBalloons(int i)
    {
        Debug.Log("trigger");
        if (dialogues[i].GetDone())
            dialogues[i].ResetOrder();
        dialogues[i].StartDialogue();
    }

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (collisionSwitch[0])
            {
                keepsakeBalloons(0);
            }
            else if (collisionSwitch[1])
            {
                bookcartBalloons(1);

            }else if (collisionSwitch[2])
            {
                vaseBalloons(2);
            }
        }
    }
}
