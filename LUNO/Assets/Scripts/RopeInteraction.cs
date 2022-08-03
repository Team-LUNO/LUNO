using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RopeInteraction : MonoBehaviour
{
    public GameObject bubble;   //E키를 유도하는 UI
    public GameObject rope;
    public GameObject ropeFinish;
    public bool ropeOnSwitch = false;   //사다리를 내려도 되는 상황인지 판단하는 bool
    public bool ropeOffSwitch = false;  //사다리를 접어도 되는 상황인지

    void Update()
    {
        if (ropeOnSwitch == true && Input.GetKeyDown(KeyCode.E))
        {
            if (bubble.activeSelf == true)
            {
                bubble.SetActive(false);
            }
            rope.SetActive(true);
            ropeFinish.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //사다리를 내릴 수 있는 공간에 있으면
        if (collision.gameObject.CompareTag("Rope1") && !ropeOnSwitch && !rope.activeSelf)
        {
            bubble.SetActive(true); //E키 bubble 활성화
            ropeOnSwitch = true;
        }

        //사다리 자동 접힘 가능
        if (collision.gameObject.CompareTag("RopeFinish") && ropeOffSwitch)
        {
            rope.SetActive(false);
            ropeOffSwitch = false;
        }

        //사다리를 탔으면
        if(collision.gameObject.CompareTag("Rope2"))
        {
            ropeOffSwitch = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //사다리를 내릴 수 있는 공간에서 벗어나면
        if (collision.gameObject.CompareTag("Rope1"))
        {
            bubble.SetActive(false);
            ropeOnSwitch = false;
        }
    }
}
