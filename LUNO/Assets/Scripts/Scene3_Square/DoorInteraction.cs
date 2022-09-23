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

    private void OnTriggerEnter2D(Collider2D other)
    {
        //graveyard
        if (other.name == "Graveyard")
        {
            UIManager.bubble[0].SetActive(true);
        }

        //lunohouse
        if(other.gameObject.CompareTag("LunohouseDoor"))
        {
            UIManager.bubble[1].SetActive(true);
        }

        //library
        if (other.gameObject.CompareTag("LibraryDoor"))
        {
            UIManager.bubble[2].SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //graveyard
        if (other.name == "Graveyard")
        {
            UIManager.bubble[0].SetActive(false);
        }

        //lunohouse
        if (other.gameObject.CompareTag("LunohouseDoor"))
        {
            UIManager.bubble[1].SetActive(false);
        }

        //library
        if (other.gameObject.CompareTag("LibraryDoor"))
        {
            UIManager.bubble[2].SetActive(false);
        }
    }

    
}
