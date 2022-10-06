using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene2_GraveyardManager : MonoBehaviour
{
    [SerializeField]
    private GameObject blackScreen;

    [SerializeField]
    private GameObject player;

    public GameObject[] bubble;

    Animator screenAnim;

    void Start()
    {
        player.GetComponent<Move>().enabled = false;
        screenAnim = blackScreen.GetComponent<Animator>();
        StartCoroutine(WaitForFadeIn());
    }

    void Update()
    {
        if (bubble[0].activeSelf && Input.GetKeyDown(KeyCode.E))    //DirectorCemetery
        {
            bubble[0].SetActive(false);
        }

        else if((bubble[1].activeSelf || bubble[2].activeSelf || bubble[3].activeSelf)
            && Input.GetKeyDown(KeyCode.E))    //Cemetery1 ~ 3
        {
            bubble[1].SetActive(false);
            bubble[2].SetActive(false);
            bubble[3].SetActive(false);
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
        SceneManager.LoadScene("Scene3_Square");
    }

    IEnumerator WaitForFadeIn()
    {
        yield return new WaitUntil(() => screenAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f);
        player.GetComponent<Move>().enabled = true;
    }

}
