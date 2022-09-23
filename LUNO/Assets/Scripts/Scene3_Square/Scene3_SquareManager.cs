using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene3_SquareManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    //camera
    public Camera cam;
    CameraController cameraController;

    //lunohouse
    [SerializeField]
    private GameObject lunohouseDetail;

    public GameObject lunohouseBubble;

    //library
    [SerializeField]
    private GameObject libraryDetail;

    [SerializeField]
    private GameObject noKeyDetail;

    [SerializeField]
    Vector3 libraryPosition;

    public GameObject libraryBubble;
    public bool detailAct = false;
    public GameObject keyImage;

    Animator detailAnim;

    //scene
    public GameObject blackScreen;
    Animator blackScreenAnim;

    //event condition
    public bool libraryEvent;
    public bool otakuEvent;
    public bool takingLegend;

    void Start()
    {
        detailAnim = lunohouseDetail.GetComponent<Animator>();
        cameraController = cam.GetComponent<CameraController>();
        blackScreenAnim = blackScreen.GetComponent<Animator>();   
    }
    void Update()
    {
        //lunohouse
        if(lunohouseBubble.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            lunohouseBubble.SetActive(false);
            lunohouseDetail.SetActive(true);
            player.GetComponent<Move>().enabled = false;
        }
        else if(lunohouseDetail.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            detailAnim = lunohouseDetail.GetComponent<Animator>();
            detailAnim.SetTrigger("PressE");
            StartCoroutine(DetailDisappear());
        }

        //library
        //Show Detail
        if (!detailAct && libraryBubble.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            detailAct = true;
            libraryBubble.SetActive(false);
            player.GetComponent<Move>().enabled = false;
            player.transform.position = libraryPosition;

            //camera move
            cameraController.targetPosition
                = new Vector3(cam.transform.position.x + 2.5f, cam.transform.position.y, cam.transform.position.z);
            cameraController.smoothTime = 0.38f;
            cameraController.cameraMove = false;
            cameraController.moveRight = true;
            StartCoroutine(DetailAppear());  //after 0.08s, Detail On
        }
        //Enter Library
        else if(detailAct && libraryBubble.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            blackScreenAnim.SetTrigger("FadeOut");
            StartCoroutine(SceneMove());
        }
        if (libraryDetail.activeSelf && Input.GetKeyDown(KeyCode.E)) //Get Key
        {
            keyImage.SetActive(true);
            libraryDetail.SetActive(false);
            noKeyDetail.SetActive(true);
        }
        else if (noKeyDetail.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            detailAnim = noKeyDetail.GetComponent<Animator>();
            detailAnim.SetTrigger("PressE");
            StartCoroutine(DetailDisappear());
        }
        
        if (libraryBubble.activeSelf && keyImage.gameObject.activeSelf
                    && Input.GetKeyDown(KeyCode.E)) //Use Key
        {
            keyImage.SetActive(false);
            blackScreenAnim.SetTrigger("FadeOut");
            StartCoroutine(SceneMove());
        }

        //village finished
        if(libraryEvent && otakuEvent && takingLegend)
        {
            blackScreenAnim.SetTrigger("FadeOut");
        }
    }

    IEnumerator DetailAppear()
    {
        yield return new WaitForSecondsRealtime(0.08f);
        libraryDetail.SetActive(true);
    }

    IEnumerator DetailDisappear()
    {
        yield return new WaitForSecondsRealtime(1f);
        lunohouseDetail.SetActive(false);
        noKeyDetail.SetActive(false);
        player.GetComponent<Move>().enabled = true;
    }

    IEnumerator SceneMove()
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene("Scene4_Library");
    }
}
