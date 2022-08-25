using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene5StartPrologue : MonoBehaviour
{

    public PrologueManager prologueManager;
    private int scene5Event; // 이 이벤트의 반복을 막기 위한 변수
    private int eventEnd;
    Move move;
    // Start is called before the first frame update
    void Start()
    {
        move = GameObject.Find("Player_Night").GetComponent<Move>();
        scene5Event = 0;
        eventEnd = 0;
        move.isOn = false;
        Invoke("StartEvent", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (eventEnd < 2)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                eventEnd += 1;
                prologueManager.IncreaseOrder();
            }
        }
        
        else
        {
            print("이동가능");
            move.isOn = true;

        }

    }

    void StartEvent()
    {
        if (scene5Event == 0)
        {
            prologueManager.StartPrologue();
        }
        scene5Event += 1;

    }
}
