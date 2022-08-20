using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveOff : MonoBehaviour
{

    public bool StoveON = false;
    public SpriteRenderer Stoverender;
    public CupHold cupHold;
    // Start is called before the first frame update
    void Awake()
    {
        cupHold = GameObject.Find("n.luno1f_cup").GetComponent<CupHold>();
        Stoverender = GameObject.Find("n.luno1f_stove").GetComponent<SpriteRenderer>();
        StoveON = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (StoveON)
        {
            Stoverender.enabled = true; // ���� �� ����
        }
        else
        {
            Stoverender.enabled = false; // ���� �� ����
  
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") // ���� �տ� �÷��̾ �� ������ �� ��� ����
        {
            if (cupHold.IsCupHold)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    StoveON = false;
                    cupHold.IsCupHold = false;
                       
                }
            }
        }
    }
}
