using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monologue : MonoBehaviour
{
    [SerializeField]
    private Move move;

    public PrologueManager prologue1;

    //private bool timeover = false;

    public void limitMove(bool isLimit)
    {
        if (isLimit)
        {
            Debug.Log("stop");
            move.isOn = false;
        }
        else
        {
            move.isOn = true;
        }
    }

    void Start()
    {
        limitMove(true);
        StartCoroutine(Timer(2f));
    }


    void Update()
    {
        /*
        if (timeover)
        {
            prologue1.StartPrologue();
            limitMove(false);
        }
        */
    }

    IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);
        //timeover = true;
        prologue1.StartPrologue();
        limitMove(false);
    }
}
