using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene2_GraveyardManager : MonoBehaviour
{
    [SerializeField]
    private GameObject blackScreen;

    public GameObject[] bubble;

    Animator screenAnim;

    void Start()
    {
        screenAnim = blackScreen.GetComponent<Animator>();
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
        //SceneManager.LoadScene("Scene3_Square");
    }
}
