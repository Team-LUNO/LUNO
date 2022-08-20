using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPrologueStove : MonoBehaviour
{
    [SerializeField]
    public PrologueManager OnprologueManager;
    public PrologueManager OFFprologueManager;
    StoveOff stoveOff;
    CupHold cupHold;

    // Start is called before the first frame update
    void Awake()
    {
        stoveOff = GameObject.Find("n.luno1f_stove").GetComponent<StoveOff>();
        cupHold = GameObject.Find("n.luno1f_cup").GetComponent<CupHold>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (stoveOff.StoveON) {
            if (cupHold.IsCupHold)
            {
                if (collision.gameObject.tag == "Player")
                {
                    OnprologueManager.StartPrologue();
                }
            }
            else if (collision.gameObject.tag == "Player")
            {
                if (OnprologueManager.GetDone()) /**/
                OnprologueManager.ResetOrder(); /**/
                OnprologueManager.StartPrologue();

            }
        }

        else if (stoveOff.StoveON!) // 난로가 꺼져 있을때 나오는 말풍선 처리
        {
            if (collision.gameObject.tag == "Player")
            {
                if (Input.GetKeyDown(KeyCode.E)) {
                    OFFprologueManager.StartPrologue();
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (stoveOff.StoveON)
        {
            OnprologueManager.IncreaseOrder();
        }

        else if (stoveOff.StoveON!) // 난로가 꺼져 있을때 나오는 말풍선 처리
        {
            OFFprologueManager.IncreaseOrder();
        }
    }
}
