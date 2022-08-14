using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public GameObject door;
    public CameraController cam;
    public Scene2_LibraryDoor_UIManager UIManager;
    Animator detailAnim;
    bool infoOnSwitch = false;
    bool doorAct = false;

    void Start()
    {
        detailAnim = door.GetComponent<Animator>();

    }
    void Update()
    {
        if(!door.activeSelf && infoOnSwitch==true && Input.GetKeyDown(KeyCode.E))
        {
            door.SetActive(true);
            //cam.DetailOn();
            doorAct = true;
            infoOnSwitch = false;
        }
        else if(door.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            UIManager.hasItem = true;
            //cam.DetailOff();
            detailAnim.SetTrigger("PressE");
            StartCoroutine(DisappearDelay());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!doorAct && collision.gameObject.CompareTag("LibraryDoor"))
        {
            infoOnSwitch = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(!doorAct && collision.gameObject.CompareTag("LibraryDoor"))
        {
            infoOnSwitch = false;
        }
    }

    IEnumerator DisappearDelay()
    {
        yield return new WaitForSecondsRealtime(1f);
        door.SetActive(false);
    }
}
