using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    GameObject diary;
    GameObject map;
    GameObject item;
    GameObject diaryContent;
    GameObject mapContent;
    
    void Start()
    {
        diary = transform.GetChild(0).gameObject;
        map = transform.GetChild(1).gameObject;
        item = transform.GetChild(2).gameObject;

        diaryContent = transform.GetChild(0).gameObject;
        mapContent = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            diary.SetActive(true);
            diaryContent.SetActive(true);
        }
        else if(diary.activeSelf && Input.GetKeyDown(KeyCode.Tab))
        {
            diary.SetActive(false);
            diaryContent.SetActive(false);

            map.SetActive(true);
            mapContent.SetActive(true);
        }
    }
}
