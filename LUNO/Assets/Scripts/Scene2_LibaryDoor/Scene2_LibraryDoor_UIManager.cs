using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2_LibraryDoor_UIManager : MonoBehaviour
{
    public GameObject door;
    public GameObject doorNoKey;
    public Camera cam;
    public Move move;
    CameraController cameraController;
    Animator detailAnim;
    public bool doorOnSwitch = false;
    public bool keyOnSwitch = false;
    public bool doorAct = false;

    [SerializeField]
    Vector3 doorPosition;

    public GameObject blackScreen;
    Animator blackScreenAnim;

    public GameObject itemImage;
    public bool hasItem;

    void Start()
    {
        detailAnim = doorNoKey.GetComponent<Animator>();
        cameraController = cam.GetComponent<CameraController>();
        blackScreenAnim = blackScreen.GetComponent<Animator>();   
    }
    void Update()
    {
        if (!door.activeSelf && doorOnSwitch == true && Input.GetKeyDown(KeyCode.E))
        {
            doorAct = true;
            doorOnSwitch = false;

            move.isOn = false;
            transform.position = doorPosition;  //지정된 위치로 이동

            //카메라 이동
            cameraController.targetPosition
                = new Vector3(cam.transform.position.x + 2.5f, cam.transform.position.y, cam.transform.position.z);
            cameraController.smoothTime = 0.38f;
            cameraController.cameraMove = false;
            cameraController.moveRight = true;
            StartCoroutine(AppearDelay());
        }
        else if (door.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            hasItem = true;
            door.SetActive(false);
            doorNoKey.SetActive(true);
        }
        else if (doorNoKey.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            detailAnim.SetTrigger("PressE");
            StartCoroutine(DisappearDelay());
        }

        if (hasItem && !itemImage.gameObject.activeSelf)
        {
            itemImage.SetActive(true);
        }
        else if (itemImage.gameObject.activeSelf && !doorNoKey.activeSelf
                    && keyOnSwitch && Input.GetKeyDown(KeyCode.E))
        {
            itemImage.SetActive(false);
            hasItem = false;
            blackScreenAnim.SetTrigger("FadeOut");
        }
    }

    IEnumerator AppearDelay()
    {
        yield return new WaitForSecondsRealtime(0.08f);
        door.SetActive(true);
    }

    IEnumerator DisappearDelay()
    {
        yield return new WaitForSecondsRealtime(1f);
        doorNoKey.SetActive(false);
        move.isOn = true;
    }
}
