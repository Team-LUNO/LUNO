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
        switch (other.gameObject.name)
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
            case "Fountain":
                UIManager.bubble[7].SetActive(true);
                break;
            case "BenchR":
                UIManager.bubble[8].SetActive(true);
                break;
            case "VillageNotice":
                UIManager.bubble[9].SetActive(true);
                break;
            case "VillageGraffiti":
                UIManager.bubble[10].SetActive(true);
                break;
            case "Adult":
                UIManager.characterBubble[1].SetActive(true);
                break;
            case "Bear":
                UIManager.characterBubble[2].SetActive(true);
                break;
            case "Teenager":
                UIManager.characterBubble[3].SetActive(true);
                break;
            case "char-05": //Cow
                UIManager.characterBubble[4].SetActive(true);
                break;
            case "char-06": //Otaku
                UIManager.characterBubble[5].SetActive(true);
                break;
            case "char-07": //Dog
                UIManager.characterBubble[6].SetActive(true);
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
            case "Fountain":
                UIManager.bubble[7].SetActive(false);
                break;
            case "BenchR":
                UIManager.bubble[8].SetActive(false);
                break;
            case "VillageNotice":
                UIManager.bubble[9].SetActive(false);
                break;
            case "VillageGraffiti":
                UIManager.bubble[10].SetActive(false);
                break;
            case "Adult":
                UIManager.characterBubble[1].SetActive(false);
                break;
            case "Bear":
                UIManager.characterBubble[2].SetActive(false);
                break;
            case "Teenager":
                UIManager.characterBubble[3].SetActive(false);
                break;
            case "char-05": //Cow
                UIManager.characterBubble[4].SetActive(false);
                break;
            case "char-06": //Otaku
                UIManager.characterBubble[5].SetActive(false);
                break;
            case "char-07": //Dog
                UIManager.characterBubble[6].SetActive(false);
                break;
        }
    }
}
