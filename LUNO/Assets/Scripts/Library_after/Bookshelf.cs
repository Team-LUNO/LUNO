using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookshelf : MonoBehaviour
{
    public popUpDetail popUpDetail;
    public Animator[] books;
    public GameObject answer;
    public int nowIndex;   //0 ~ 5번 공간
    bool prologueOn = false;
    bool bookActive;

    [SerializeField]
    private PrologueManager prologueManager;

    void Start()
    {
        nowIndex = 0;
        bookActive = true;
    }

    void Update()
    {
        if(!prologueOn && bookActive)
        {
            //왼쪽 빈 공간 열림, 책이 오른쪽으로
            if (Input.GetKeyDown(KeyCode.A) && nowIndex > 0 && nowIndex <= 5)
            {
                nowIndex--;
                books[nowIndex].SetTrigger("MoveRight");
            }
            //오른쪽 빈 공간 열림, 책이 왼쪽으로
            else if (Input.GetKeyDown(KeyCode.D) && nowIndex >= 0 && nowIndex < 5)
            {
                nowIndex++;
                books[nowIndex - 1].SetTrigger("MoveLeft");
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                if (prologueManager.GetDone())
                    prologueManager.ResetOrder();
                prologueManager.StartPrologue();
                prologueOn = true;
            }
        }
        if(answer.activeSelf)
        {
            StartCoroutine(ShowBookshelf());
        }
    }

    public void PrologueOff()
    {
        prologueOn = false;
        prologueManager.IncreaseOrder();
    }

    IEnumerator ShowBookshelf()
    {
        yield return new WaitForSecondsRealtime(1f);
        popUpDetail.closePopUp();
        bookActive = false;
    }
}
