using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S1_2_02_16_Scripts : MonoBehaviour
{
    [SerializeField]
    private PrologueManager prologue1;

    private bool isFirst = true;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isFirst)
        {
            prologue1.StartPrologue();
            isFirst = false;
        }
    }

}
