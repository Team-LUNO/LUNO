using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EInteractionInLibrary : MonoBehaviour
{
    public int nowStatus = 0;
    //nowStatus 0: 처음 / 1: 책 들고 있음 / 2: 책 내려놓음 
    public bool[] collisionSwitch;
    // collisionSwitch [0]: keepsake / [1]: bookcart

    public PrologueManager prologue1;
    public PrologueManager prologue2;
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
        }
    }

    void keepsakeBalloons()
    {
        if (prologue1.GetDone())
            prologue1.ResetOrder();
        prologue1.StartPrologue();
    }

    void bookcartBalloons()
    {

        cnt = s1.getCnt();
        Debug.Log(cnt);
        Debug.Log(s1.prologueManagers[cnt].GetDone());
        if (s1.prologueManagers[cnt].GetDone())
            prologue2.ResetOrder();
        prologue2.StartPrologue();
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
                keepsakeBalloons();
            }
            else if (collisionSwitch[1])
            {
                bookcartBalloons();
            }
        }
    }
}
