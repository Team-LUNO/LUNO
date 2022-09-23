using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    [SerializeField]
    private Scene3_SquareManager UIManager;

    void Start()
    {
        
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //library
        if (collision.gameObject.CompareTag("LibraryDoor"))
        {
            UIManager.libraryBubble.SetActive(true);
        }

        //lunohouse
        if(collision.gameObject.CompareTag("LunohouseDoor"))
        {
            UIManager.lunohouseBubble.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //library
        if(collision.gameObject.CompareTag("LibraryDoor"))
        {
            UIManager.libraryBubble.SetActive(false);
        }

        //lunohouse
        if (collision.gameObject.CompareTag("LunohouseDoor"))
        {
            UIManager.lunohouseBubble.SetActive(false);
        }
    }

    
}
