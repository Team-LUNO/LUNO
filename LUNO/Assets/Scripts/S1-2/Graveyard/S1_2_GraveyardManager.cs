using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S1_2_GraveyardManager : MonoBehaviour
{
    [SerializeField]
    private GameObject blackScreen;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject[] objDetail;

    [SerializeField]
    private PrologueManager[] prologues;

    Animator screenAnim;
    Animator detailAnim;
    int prologueIndex;
    public GameObject[] objBubble;


    void Start()
    {
        player.GetComponent<Move>().enabled = false;
        screenAnim = blackScreen.GetComponent<Animator>();
        StartCoroutine(WaitForAnimation());
    }

    void Update()
    {
        if (prologueIndex == 2)
        {
            prologueIndex = 0;
        }

        if (objBubble[0].activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            player.GetComponent<Move>().enabled = false;
            objBubble[0].SetActive(false);
            objDetail[0].SetActive(true);
        }
        else if(objBubble[1].activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            objBubble[1].SetActive(false);
            if (prologues[prologueIndex].GetDone())
            {
                prologues[prologueIndex].ResetOrder();
            }
            prologues[prologueIndex].StartPrologue();
            prologueIndex++;
        }
        else if (objBubble[2].activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            player.GetComponent<Move>().enabled = false;
            objBubble[2].SetActive(false);
            objDetail[1].SetActive(true);
        }

        if(objDetail[0].activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            detailAnim = objDetail[0].GetComponent<Animator>();
            detailAnim.SetTrigger("PressE");
        }
        else if (objDetail[1].activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            detailAnim = objDetail[1].GetComponent<Animator>();
            detailAnim.SetTrigger("PressE");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        screenAnim.SetTrigger("FadeOut");
        StartCoroutine(SceneMoveDelay());
    }

    IEnumerator SceneMoveDelay()
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene("Scene2_LibraryDoor");
    }

    IEnumerator WaitForAnimation()
    {
        yield return new WaitUntil(() => screenAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f);
        player.GetComponent<Move>().enabled = true;
    }
}
