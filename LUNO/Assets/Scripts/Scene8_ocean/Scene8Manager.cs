using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene8Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject inventory;

    [SerializeField]
    private GameObject bag;

    [SerializeField]
    private GameObject itemInBag;

    [SerializeField]
    private GameObject itemInGame;

    [SerializeField]
    private PrologueManager prologue;

    private int order = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (order == 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                inventory.SetActive(true);
                player.GetComponent<Move>().enabled = false;
                order++;
            }
        }
        else if(order == 1)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                bag.GetComponent<Animator>().SetBool("close", true);
                itemInBag.SetActive(false);
                Invoke("CloseInventory", 1f);
                itemInGame.SetActive(true);
                order++;
            }
        }
        else if (order == 2)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                prologue.StartPrologue();
                itemInGame.SetActive(false);
                order++;
            }
        }
    }

    private void CloseInventory()
    {
        inventory.SetActive(false);
        player.GetComponent<Move>().enabled = true;
    }
}
