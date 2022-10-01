using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    [SerializeField]
    private Scene3_SquareManager UIManager;

    [SerializeField]
    private DialogueManager elderDialogue;

    bool elder1Finished;

    void Start()
    {
        
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Graveyard")
        {
            UIManager.bubble[0].SetActive(true);
        }
        else if(other.name == "Forest1")
        {
            UIManager.bubble[1].SetActive(true);
        }
        else if (other.name == "Forest2")
        {
            UIManager.bubble[2].SetActive(true);
        }
        else if (other.name == "Forest3")
        {
            UIManager.bubble[3].SetActive(true);
        }
        else if(other.name == "Lunohouse")
        {
            UIManager.bubble[4].SetActive(true);
        }
        else if (other.name == "Library")
        {
            UIManager.bubble[5].SetActive(true);
        }
        else if (other.name == "Fountain")
        {
            UIManager.bubble[9].SetActive(true);
        }
        else if(other.name == "BabyBear")
        {
            UIManager.bubble[12].SetActive(true);
        }
        else if (other.name == "Dog")
        {
            UIManager.bubble[13].SetActive(true);
        }
        else if(other.name == "Elder")
        {
            if(!elder1Finished)
            {
                elderDialogue.StartDialogue();
                elder1Finished = true;
            }
            else
            {
                UIManager.bubble[14].SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Graveyard")
        {
            UIManager.bubble[0].SetActive(false);
        }
        else if (other.name == "Forest1")
        {
            UIManager.bubble[1].SetActive(false);
        }
        else if (other.name == "Forest2")
        {
            UIManager.bubble[2].SetActive(false);
        }
        else if (other.name == "Forest3")
        {
            UIManager.bubble[3].SetActive(false);
        }
        else if (other.name == "Lunohouse")
        {
            UIManager.bubble[4].SetActive(false);
        }
        else if (other.name == "Library")
        {
            UIManager.bubble[5].SetActive(false);
        }
        else if(other.name == "Fountain")
        {
            UIManager.bubble[9].SetActive(false);
        }
        else if (other.name == "BabyBear")
        {
            UIManager.bubble[12].SetActive(false);
        }
        else if (other.name == "Dog")
        {
            UIManager.bubble[13].SetActive(false);
        }
        else if(other.name == "Elder" && elder1Finished)
        {
            UIManager.bubble[14].SetActive(false);
        }
    }

    
}
