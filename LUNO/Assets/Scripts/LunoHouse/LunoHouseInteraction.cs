using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunoHouseInteraction : MonoBehaviour
{
    [SerializeField]
    CameraController cameraController;

    [SerializeField]
    CameraController_2F cameraController_2F;

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
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("InteractionObject"))
        {
            collision.transform.GetChild(0).gameObject.SetActive(false);
        }
        else if(collision.CompareTag("Ladder"))
        {
            collision.gameObject.SetActive(false);
            //1F
            if(transform.position.y < playerPosition)
            {
                cameraController.enabled = true;
            }
            //2F
            else
            {
                cameraController_2F.enabled = true;
            }
        }
    }
}
