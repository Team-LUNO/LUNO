using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsterSpeech : MonoBehaviour
{
    public PrologueManager prologue;

    void Start()
    {
        StartCoroutine(speech());
    }


    IEnumerator speech()
    {
        yield return new WaitForSeconds(4.5f);
        prologue.StartPrologue();
    }
}
