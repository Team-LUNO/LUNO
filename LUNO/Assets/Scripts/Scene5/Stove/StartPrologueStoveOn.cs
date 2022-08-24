using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPrologueStoveOn : MonoBehaviour
{
    [SerializeField]
    private PrologueManager OnprologueManager;
    StoveOff stoveOff;
    CupHold cupHold;

    // Start is called before the first frame update
    void Awake()
    {
        stoveOff = GameObject.Find("n.luno1f_stoveOn").GetComponent<StoveOff>();
        cupHold = GameObject.Find("n.luno1f_cup").GetComponent<CupHold>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (stoveOff.StoveON)
        {
            if (cupHold.IsCupHold)
            {
                if (collision.gameObject.tag == "Player")
                {
                    OnprologueManager.StartPrologue();
                }
            }
            else if (collision.gameObject.tag == "Player")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (OnprologueManager.GetDone()) /**/
                        OnprologueManager.ResetOrder(); /**/
                    OnprologueManager.StartPrologue();
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
    }
}
