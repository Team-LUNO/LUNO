using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveNextScene : MonoBehaviour
{
    public GameObject blackScreen;
    Animator anim;

    void Start()
    {
        anim = blackScreen.GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        anim.SetTrigger("FadeOut");
        StartCoroutine(SceneMoveDelay());
    }

    IEnumerator SceneMoveDelay()
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene("Scene2_LibraryDoor");
    }
}
