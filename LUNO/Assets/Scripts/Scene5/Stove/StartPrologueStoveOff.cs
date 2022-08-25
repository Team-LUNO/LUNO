using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPrologueStoveOff : MonoBehaviour
{
    [SerializeField]
    public PrologueManager OffprologueManager1;
    public PrologueManager OffprologueManager2;
    public int EventNum;
    StoveOff stoveOff;
    CupHold cupHold;
    Move move;

    // Start is called before the first frame update
    void Awake()
    {
        stoveOff = GameObject.Find("n.luno1f_stoveOn").GetComponent<StoveOff>();
        cupHold = GameObject.Find("n.luno1f_cup").GetComponent<CupHold>();
        EventNum = 0;
        if (move == null)
        {
            if (GameObject.Find("Player_Night"))
                move = GameObject.Find("Player_Night").GetComponent<Move>();

            else if (GameObject.Find("Player"))
                move = GameObject.Find("Player").GetComponent<Move>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {


        if (cupHold.IsCupHold)
        {
            if (collision.gameObject.tag == "Player")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {

                    if (EventNum == 0)
                    {
                        //move.isOn = false;
                        OffprologueManager1.StartPrologue();
                        EventNum = 1;
                        Debug.Log("EventNum1 증가");

                    }
                 


                }


            }
        }
        else
        {
            if (collision.gameObject.tag == "Player")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (EventNum == 2)
                    {
                        //move.isOn = false;
                        OffprologueManager2.StartPrologue();
                        EventNum = 3;
                        Debug.Log("EventNum3 증가");


                    }
                    else if (EventNum == 4)
                    {
                        Debug.Log("탈출");
                    }
                }
            }
        }



    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (EventNum == 1)
        {
            //move.isOn = false;
            OffprologueManager1.IncreaseOrder();
            EventNum = 2;
            Debug.Log("EventNum2 증가");


        }
        else if (EventNum == 3)
        {
            //move.isOn = false;
            OffprologueManager2.IncreaseOrder();
            EventNum = 4;
            Debug.Log("EventNum4 증가");
        }
    }
}
