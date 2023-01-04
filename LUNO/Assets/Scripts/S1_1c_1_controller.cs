using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class S1_1c_1_controller : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector director1;

    [SerializeField]
    private PlayableDirector director2;

    [SerializeField]
    private PlayableDirector director3;

    [SerializeField]
    private PlayableDirector director4;

    [SerializeField]
    private DialogueManager dialogue1;

    [SerializeField]
    private DialogueManager dialogue2;

    private int order = 1;
    private bool timeover = false;

    // Start is called before the first frame update
    void Start()
    {
        director1.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (director1.state != PlayState.Playing && order == 1)
        {
            director2.Play();
            order++;
        }
        else if (order == 2)
        {
            StartCoroutine(Timer(5f));
            if (timeover)
            {
                dialogue1.StartDialogue();
                order++;
            }
        }
        else if (order == 3 && dialogue1.GetDone())
        {
            timeover = false;
            director3.Play();
            order++;
        }
        else if (order == 4)
        {
            StartCoroutine(Timer(4.0f));
            if (timeover)
            {
                dialogue2.StartDialogue();
                order++;
            }
        }
        else if (order == 5 && dialogue2.GetDone())
        {
            timeover = false;
            director4.Play();
            order++;
        }
    }

    IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);
        timeover = true;
        Debug.Log("time over");
    }
}
