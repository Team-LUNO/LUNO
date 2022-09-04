using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryOpenClose : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject dimmendSolid;

    [SerializeField]
    private GameObject bag;

    private int slotNum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            OpenInventory();
        }

        if (bag.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return))
            {
                slotNum = GetComponent<InventorySlotMove>().GetSlotNum();
                bag.transform.GetChild(slotNum - 1).transform.GetChild(0).GetComponent<Image>().enabled = false;
                bag.GetComponent<Animator>().SetBool("close", true);
                Invoke("CloseInventory", 1f);
            }
        }
    }

    private void OpenInventory()
    {
        dimmendSolid.SetActive(true);
        bag.SetActive(true);
        player.GetComponent<Move>().enabled = false;
    }

    private void CloseInventory()
    {
        dimmendSolid.SetActive(false);
        bag.SetActive(false);
        GetComponent<InventorySlotMove>().ResetSlotNum();
        player.GetComponent<Move>().enabled = true;
    }
}
