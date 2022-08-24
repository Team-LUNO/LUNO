using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public GameObject door;
    public GameObject doorNoKey;
    public Camera cam;
    CameraController cameraController;
    public Scene2_LibraryDoor_UIManager UIManager;
    Animator detailAnim;
    bool infoOnSwitch = false;
    bool doorAct = false;

    [SerializeField]
    Vector3 doorPosition;

    void Start()
    {
        detailAnim = door.GetComponent<Animator>();
        cameraController = cam.GetComponent<CameraController>();
    }
    void Update()
    {
        if(!door.activeSelf && infoOnSwitch==true && Input.GetKeyDown(KeyCode.E))
        {
            transform.position = doorPosition;  //지정된 위치로 이동
            door.SetActive(true);

            //카메라 이동
            cameraController.targetPosition
                = new Vector3(cam.transform.position.x + 2.5f, cam.transform.position.y, cam.transform.position.z);
            cameraController.smoothTime = 0.38f;
            cameraController.cameraMove = false;
            cameraController.moveRight = true;

            doorAct = true;
            infoOnSwitch = false;
        }
        else if(door.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            UIManager.hasItem = true;

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
