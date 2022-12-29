using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveyardInteraction : MonoBehaviour
{
    public Scene2_GraveyardManager UIManager;

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
            case "DirectorCemetery":
                UIManager.interactionObjects[0].transform.GetChild(0).gameObject.SetActive(true);
                break;
            case "Cemetery1":
                UIManager.interactionObjects[1].transform.GetChild(0).gameObject.SetActive(true);
                break;
            case "Cemetery2":
                UIManager.interactionObjects[2].transform.GetChild(0).gameObject.SetActive(true);
                break;
            case "Cemetery3":
                UIManager.interactionObjects[3].transform.GetChild(0).gameObject.SetActive(true);
                break;
            case "Cemetery4":
                UIManager.interactionObjects[4].transform.GetChild(0).gameObject.SetActive(true);
                break;
            case "Cemetery5":
                UIManager.interactionObjects[5].transform.GetChild(0).gameObject.SetActive(true);
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        switch (other.gameObject.name)
        {
            case "DirectorCemetery":
                UIManager.interactionObjects[0].transform.GetChild(0).gameObject.SetActive(false);
                break;
            case "Cemetery1":
                UIManager.interactionObjects[1].transform.GetChild(0).gameObject.SetActive(false);
                break;
            case "Cemetery2":
                UIManager.interactionObjects[2].transform.GetChild(0).gameObject.SetActive(false);
                break;
            case "Cemetery3":
                UIManager.interactionObjects[3].transform.GetChild(0).gameObject.SetActive(false);
                break;
            case "Cemetery4":
                UIManager.interactionObjects[4].transform.GetChild(0).gameObject.SetActive(false);
                break;
            case "Cemetery5":
                UIManager.interactionObjects[5].transform.GetChild(0).gameObject.SetActive(false);
                break;
        }
    }
}
