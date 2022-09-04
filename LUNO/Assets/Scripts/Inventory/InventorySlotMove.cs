using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotMove : MonoBehaviour
{
    [SerializeField]
    private GameObject bag;

    private int slotNum = 1;

    public int GetSlotNum()
    {
        return slotNum;
    }

    public void ResetSlotNum()
    {
        bag.transform.GetChild(slotNum - 1).GetComponent<Image>().enabled = false;
        slotNum = 1;
        bag.transform.GetChild(slotNum - 1).GetComponent<Image>().enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        slotNum = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (bag.activeSelf)
        {
            if ((slotNum >= 1 && slotNum <= 3) || (slotNum >= 5 && slotNum <= 7))
            {
                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                {
                    bag.transform.GetChild(slotNum - 1).GetComponent<Image>().enabled = false;
                    slotNum++;
                    bag.transform.GetChild(slotNum - 1).GetComponent<Image>().enabled = true;
                }
            }
            if ((slotNum >= 2 && slotNum <= 4) || (slotNum >= 6 && slotNum <= 8))
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                {
                    bag.transform.GetChild(slotNum - 1).GetComponent<Image>().enabled = false;
                    slotNum--;
                    bag.transform.GetChild(slotNum - 1).GetComponent<Image>().enabled = true;
                }
            }

            if (slotNum >= 1 && slotNum <= 4)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                {
                    bag.transform.GetChild(slotNum - 1).GetComponent<Image>().enabled = false;
                    slotNum += 4;
                    bag.transform.GetChild(slotNum - 1).GetComponent<Image>().enabled = true;
                }
            }
            else if (slotNum >= 5 && slotNum <= 8)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                {
                    bag.transform.GetChild(slotNum - 1).GetComponent<Image>().enabled = false;
                    slotNum -= 4;
                    bag.transform.GetChild(slotNum - 1).GetComponent<Image>().enabled = true;
                }

                if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                {
                    bag.transform.GetChild(slotNum - 1).GetComponent<Image>().enabled = false;
                    slotNum = 9;
                    bag.transform.GetChild(slotNum - 1).GetComponent<Image>().enabled = true;
                }
            }
            else if (slotNum == 9)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                {
                    bag.transform.GetChild(slotNum - 1).GetComponent<Image>().enabled = false;
                    slotNum = 5;
                    bag.transform.GetChild(slotNum - 1).GetComponent<Image>().enabled = true;
                }
            }
        }
    }
}
