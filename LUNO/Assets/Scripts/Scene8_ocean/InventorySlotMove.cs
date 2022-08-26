using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotMove : MonoBehaviour
{
    [SerializeField]
    private GameObject slots;

    private int slotNum = 1;

    // Start is called before the first frame update
    void Start()
    {
        slotNum = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if((slotNum >= 1 && slotNum <=3) || (slotNum >= 5 && slotNum <= 7))
        {
            if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                slots.transform.GetChild(slotNum - 1).GetComponent<Image>().enabled = false;
                slotNum++;
                slots.transform.GetChild(slotNum - 1).GetComponent<Image>().enabled = true;
            }
        }
        if ((slotNum >= 2 && slotNum <= 4) || (slotNum >= 6 && slotNum <= 8))
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                slots.transform.GetChild(slotNum - 1).GetComponent<Image>().enabled = false;
                slotNum--;
                slots.transform.GetChild(slotNum - 1).GetComponent<Image>().enabled = true;
            }
        }
        if (slotNum >= 1 && slotNum <= 4)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                slots.transform.GetChild(slotNum - 1).GetComponent<Image>().enabled = false;
                slotNum += 4;
                slots.transform.GetChild(slotNum - 1).GetComponent<Image>().enabled = true;
            }
        }
        if (slotNum >= 5 && slotNum <= 8)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                slots.transform.GetChild(slotNum - 1).GetComponent<Image>().enabled = false;
                slotNum -= 4;
                slots.transform.GetChild(slotNum - 1).GetComponent<Image>().enabled = true;
            }
        }
    }
}
