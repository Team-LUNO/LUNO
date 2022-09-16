using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S1_3_02_Scripts : MonoBehaviour
{
    public PrologueManager[] prologues;
    private bool isFirst = true;
    bool isColliderin = false;
    int i = 0;

    [SerializeField]
    private S1_2_VillageManager UIManager;

    private void Update()
    {
        if (isColliderin && Input.GetKeyDown(KeyCode.G))
        {
            if (i == 8)
            {
                Debug.Log(prologues[i - 1].GetDone());
            }
            if (isFirst)
            {
                prologues[i].StartPrologue();
                isFirst = false;
                i++;
            }
            else if (!isFirst && prologues[i - 1].GetDone())
            {
                prologues[i].ResetOrder();
                prologues[i].StartPrologue();
                if (i < prologues.Length)
                {
                    i++;
                }
            }
            else if (!isFirst && !prologues[i - 1].GetDone())
            {
                prologues[i - 1].ResetOrder();
                prologues[i - 1].StartPrologue();
            }
        }

        if(prologues[prologues.Length-1].GetDone() && !UIManager.otakuEvent)
        {
            UIManager.otakuEvent = true;
        }
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger");
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
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isColliderin = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isColliderin = false;
    }
}
