using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveStoneInteraction : MonoBehaviour
{
    public S1_2_GraveyardManager UIManager;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.name == "obj-01-01")
        {
            UIManager.objBubble[0].SetActive(true);
        }
        else if (collider.name == "obj-01-02")
        {
            UIManager.objBubble[1].SetActive(true);
        }
        else if(collider.name == "obj-01-03")
        {
            UIManager.objBubble[2].SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.name == "obj-01-01")
        {
            UIManager.objBubble[0].SetActive(false);
        }
        else if (collider.name == "obj-01-02")
        {
            UIManager.objBubble[1].SetActive(false);
        }
        else if (collider.name == "obj-01-03")
        {
            UIManager.objBubble[2].SetActive(false);
        }
    }
}
