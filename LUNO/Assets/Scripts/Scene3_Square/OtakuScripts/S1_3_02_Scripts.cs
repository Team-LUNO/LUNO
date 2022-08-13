using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S1_3_02_Scripts : MonoBehaviour
{
    public PrologueManager[] prologues;
    private bool isFirst = true;
    int i = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(i == 8)
        {
            Debug.Log(prologues[i - 1].GetDone());
        }
        if (isFirst)
        {
            prologues[i].StartPrologue();
            isFirst = false;
            i++;
        }
        else if (!isFirst && prologues[i-1].GetDone())
        {
            prologues[i].ResetOrder();
            prologues[i].StartPrologue();
            if (i < prologues.Length)
            {
                i++;
            }
        }else if(!isFirst && !prologues[i - 1].GetDone())
        {
            prologues[i-1].ResetOrder();
            prologues[i-1].StartPrologue();
        }
    }
}
