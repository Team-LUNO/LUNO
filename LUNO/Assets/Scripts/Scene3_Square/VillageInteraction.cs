using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageInteraction : MonoBehaviour
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
        switch(other.gameObject.name)
        {
            case "Graveyard":
                UIManager.bubble[0].SetActive(true);
                break;
            case "Forest":
                UIManager.bubble[1].SetActive(true);
                break;
            case "Lunohouse":
                UIManager.bubble[2].SetActive(true);
                break;
            case "Library":
                UIManager.bubble[3].SetActive(true);
                break;
            case "Ladder1":
                UIManager.bubble[4].SetActive(true);
                break;
            case "House1":
                UIManager.bubble[5].SetActive(true);
                break;
            case "Bench1":
                UIManager.bubble[6].SetActive(true);
                break;
            case "Fountain":
                UIManager.bubble[7].SetActive(true);
                break;
            case "Bench2":
                UIManager.bubble[8].SetActive(true);
                break;
            case "House2":
                UIManager.bubble[9].SetActive(true);
                break;
            case "BabyBear":
                UIManager.bubble[10].SetActive(true);
                break;
            case "Otaku":
                UIManager.bubble[11].SetActive(true);
                break;
            case "Dog":
                UIManager.bubble[12].SetActive(true);
                break;
            case "OldDog":
                UIManager.bubble[13].SetActive(true);
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        switch (other.gameObject.name)
        {
            case "Graveyard":
                UIManager.bubble[0].SetActive(false);
                break;
            case "Forest":
                UIManager.bubble[1].SetActive(false);
                break;
            case "Lunohouse":
                UIManager.bubble[2].SetActive(false);
                break;
            case "Library":
                UIManager.bubble[3].SetActive(false);
                break;
            case "Ladder1":
                UIManager.bubble[4].SetActive(false);
                break;
            case "House1":
                UIManager.bubble[5].SetActive(false);
                break;
            case "Bench1":
                UIManager.bubble[6].SetActive(false);
                break;
            case "Fountain":
                UIManager.bubble[7].SetActive(false);
                break;
            case "Bench2":
                UIManager.bubble[8].SetActive(false);
                break;
            case "House2":
                UIManager.bubble[9].SetActive(false);
                break;
            case "BabyBear":
                UIManager.bubble[10].SetActive(false);
                break;
            case "Otaku":
                UIManager.bubble[11].SetActive(false);
                break;
            case "Dog":
                UIManager.bubble[12].SetActive(false);
                break;
            case "OldDog":
                UIManager.bubble[13].SetActive(false);
                break;
        }
    }

    
}
