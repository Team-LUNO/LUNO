using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public GameObject dimmedSolid;
    GameObject diary;
    public GameObject map;
    //GameObject item;

    bool noteOn = false;
    int noteIndex;
    
    void Start()
    {
        diary = transform.GetChild(0).gameObject;
        map = transform.GetChild(1).gameObject;
        //item = transform.GetChild(2).gameObject;
    }

    void Update()
    {
        if(!noteOn && Input.GetKeyDown(KeyCode.Tab))
        {
            noteIndex = 0;
            noteOn = true;
            dimmedSolid.SetActive(true);
            diary.SetActive(true);
        }
        else if(noteOn && noteIndex == 0 && Input.GetKeyDown(KeyCode.Tab))
        {
            noteIndex = 1;
            diary.SetActive(false);
            map.SetActive(true);
        }
        else if(noteOn && Input.GetKeyDown(KeyCode.Escape))
        {
            dimmedSolid.SetActive(false);
            noteOn = false;
            if(noteIndex == 0)
            {
                diary.SetActive(false);
            }
            else if(noteIndex == 1)
            {
                map.SetActive(false);
            }
        }
    }
}
