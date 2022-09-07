using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public S1_2_Village_UIManager UIManager;

    void Start()
    {
        
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!UIManager.doorAct && collision.gameObject.CompareTag("LibraryDoor"))
        {
            UIManager.doorOnSwitch = true;
        }

        if(UIManager.hasItem && collision.gameObject.CompareTag("LibraryDoor"))
        {
            UIManager.keyOnSwitch = true;
        }

        if(collision.gameObject.CompareTag("LunohouseDoor"))
        {
            UIManager.lunohouseOnSwitch = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(!UIManager.doorAct && collision.gameObject.CompareTag("LibraryDoor"))
        {
            UIManager.doorOnSwitch = false;
        }

        if (UIManager.hasItem && collision.gameObject.CompareTag("LibraryDoor"))
        {
            UIManager.keyOnSwitch = false;
        }

        if(collision.gameObject.CompareTag("LunohouseDoor"))
        {
            UIManager.lunohouseOnSwitch = false;
        }
    }

    
}
