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
                UIManager.bubble[0].SetActive(true);
                break;
            case "Cemetery1":
                UIManager.bubble[1].SetActive(true);
                break;
            case "Cemetery2":
                UIManager.bubble[2].SetActive(true);
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        switch (other.gameObject.name)
        {
            case "DirectorCemetery":
                UIManager.bubble[0].SetActive(false);
                break;
            case "Cemetery1":
                UIManager.bubble[1].SetActive(false);
                break;
            case "Cemetery2":
                UIManager.bubble[2].SetActive(false);
                break;
        }
    }
}
