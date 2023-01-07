using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunoHouseInteraction : MonoBehaviour
{
    [SerializeField]
    LunoHouseManager lunoHouseManager;

    [SerializeField]
    float playerPosition;

    void Start()
    {

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("InteractionObject"))
        {
            collision.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if(collision.CompareTag("Ladder"))
        {
            if(lunoHouseManager.firstPlay)
            {
                lunoHouseManager.moveInfo.SetActive(false);
                lunoHouseManager.ladderInfo.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("InteractionObject"))
        {
            collision.transform.GetChild(0).gameObject.SetActive(false);
        }
        else if(collision.CompareTag("Ladder"))
        {
            if(lunoHouseManager.firstPlay)
            {
                lunoHouseManager.ladderInfo.SetActive(false);
                lunoHouseManager.firstPlay = false;
            }

            collision.gameObject.SetActive(false);
            //1F
            if(transform.position.y < playerPosition)
            {
                lunoHouseManager.cameraController.enabled = true;
            }
            //2F
            else
            {
                lunoHouseManager.cameraController_2F.enabled = true;
            }
        }
    }
}
