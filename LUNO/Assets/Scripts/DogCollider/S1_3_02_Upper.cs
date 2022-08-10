using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S1_3_02_Upper : MonoBehaviour
{
    public PrologueManager prologue1;
    public PrologueManager prologue2;

    private bool isFirst = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isFirst)
        {
            prologue1.StartPrologue();
            isFirst = false;
        }
        else if (!isFirst && prologue1.GetDone())
        {
            prologue2.ResetOrder();
            prologue2.StartPrologue();
        }
    }
}
