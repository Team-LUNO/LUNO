using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionBalloons : MonoBehaviour
{
    public PrologueManager prologue1;
    public PrologueManager prologue2;
    public S1_03_selection s1;

    public bool isExit=true;
    private int cnt;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("keepsake"))
        {
            if (prologue1.GetDone())
                prologue1.ResetOrder();
            prologue1.StartPrologue();
        }
        else if (collision.CompareTag("bookcart"))
        {
            //Debug.Log("trigger");
            cnt = s1.getCnt();
            Debug.Log(s1.prologueManagers[cnt].GetDone());
            if (s1.prologueManagers[cnt].GetDone())     
                prologue2.ResetOrder();
            prologue2.StartPrologue();
        }
    }
}
