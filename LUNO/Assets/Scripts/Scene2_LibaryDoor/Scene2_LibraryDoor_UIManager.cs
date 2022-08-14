using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2_LibraryDoor_UIManager : MonoBehaviour
{
    public GameObject blackScreen;
    public GameObject itemImage;
    Animator blackScreenAnim;

    public bool hasItem;
    void Start()
    {
        blackScreenAnim = blackScreen.GetComponent<Animator>();   
    }
    void Update()
    {
        if(hasItem && !itemImage.gameObject.activeSelf)
        {
            itemImage.SetActive(true);
        }
        else if (hasItem && itemImage.gameObject.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            itemImage.SetActive(false);
            hasItem = false;
            blackScreenAnim.SetTrigger("FadeOut");
        }
    }
}
