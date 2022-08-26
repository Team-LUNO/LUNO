using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public GameObject dimmedSolid;
    public GameObject diary;
    public GameObject map;

    public GameObject diaryContent;
    public GameObject mapForest;

    bool noteOn = false;
    int noteIndex;
    
    void Start()
    {

    }

    void Update()
    {
        if(!noteOn && Input.GetKeyDown(KeyCode.Tab))
        {
            noteIndex = 0;
            noteOn = true;
            dimmedSolid.SetActive(true);
            
            StartCoroutine(DiaryOn());
        }
        else if(noteOn && noteIndex == 0 && Input.GetKeyDown(KeyCode.Tab))
        {
            noteIndex = 1;
            diary.SetActive(false);
            diaryContent.SetActive(false);

            StartCoroutine(MapOn());
        }
        else if(noteOn && Input.GetKeyDown(KeyCode.Escape))
        {
            dimmedSolid.SetActive(false);
            noteOn = false;
            if(noteIndex == 0)
            {
                diary.SetActive(false);
                diaryContent.SetActive(false);
            }
            else if(noteIndex == 1)
            {
                map.SetActive(false);
                mapForest.SetActive(false);
            }
        }
    }

    IEnumerator DiaryOn()
    {
        diary.SetActive(true);
        yield return new WaitForSeconds(1f);
        diaryContent.SetActive(true);
    }

    IEnumerator MapOn()
    {
        map.SetActive(true);
        yield return new WaitForSeconds(2f);
        mapForest.SetActive(true);
    }
}
