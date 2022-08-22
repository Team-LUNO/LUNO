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
        move = GameObject.Find("Player_Night").GetComponent<Move>();
        EventNum = 0;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (cupHold.CupEvent > 0)
        {
            if (collision.gameObject.tag == "Player")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (EventNum == 0) {
                        OffprologueManager1.StartPrologue();
                    }
                    else if (EventNum == 1) {
                        OffprologueManager2.StartPrologue();
                    }
                    else if (EventNum == 2)
                    {
                        print("Å»Ãâ");
                    }

                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (cupHold.CupEvent > 0)
        {
            if (EventNum == 0)
            {
                OffprologueManager1.IncreaseOrder();
                EventNum += 1;
            }
            else if (EventNum == 1)
            {
                OffprologueManager2.IncreaseOrder();
                EventNum += 1;
            }
            
        }
    }
}
