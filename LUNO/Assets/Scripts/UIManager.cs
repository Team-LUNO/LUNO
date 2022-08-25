using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //public GameObject keyDescription;   //조작키 설명창
    public GameObject itemImage;    //사용 중인 아이템 이미지
    Move move;

    //Animator descriptionAnim;   //조작키 설명창 애니메이션
    //public bool descriptionAct; //한 번만 실행되게하기 위한 플래그
    public bool playerMove; //플레이어 움직임 가능 여부
    public bool hasItem;    //아이템 소지 여부


    // Start is called before the first frame update
    void Start()
    {
        if (move == null)
        {
            if (GameObject.Find("Player_Night"))
                move = GameObject.Find("Player_Night").GetComponent<Move>();

            else if (GameObject.Find("Player"))
                move = GameObject.Find("Player").GetComponent<Move>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //조작키 설명창 띄우기
        //설명창이 한 번도 띄워진 적이 없음 && 설명창이 현재 비활성화 상태 && 아무키나 누를 시
        /*if (!descriptionAct && !keyDescription.gameObject.activeSelf && Input.anyKeyDown)
        {
            keyDescription.SetActive(true);
            move.isOn = false; //플레이어 못 움직이게
        }

        //조작키 설명창 닫기
        //설명창이 한 번도 띄워진 적이 없음 && 설명창이 현재 활성화 상태 && Esc/Q키를 누를 시
        else if (!descriptionAct && keyDescription.gameObject.activeSelf
            && (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Q)))
        {
            descriptionAct = true;  //한 번 실행됨 표시
            descriptionAnim.SetTrigger("disappear");
            move.isOn = true;
            StartCoroutine(DisappearDelay());
        }*/

        //아이템 사용
        //아이템을 가지고 있음 && 아이템 이미지가 비활성화 상태
        if (hasItem && !itemImage.gameObject.activeSelf)
        {
            itemImage.SetActive(true);
        }
        //아이템을 가지고 있음 && 아이템 이미지가 활성화 상태 && E키 누를 시
        else if (hasItem && itemImage.gameObject.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            itemImage.SetActive(false);
            hasItem = false;
            Debug.Log("아이템 사용");
        }
    }

    //애니메이션 실행 후에 창이 닫히도록 딜레이 설정
    /*IEnumerator DisappearDelay()
    {
        yield return new WaitForSecondsRealtime(0.75f);
        keyDescription.SetActive(false);
        Debug.Log("조작키 설명창 닫힘");

    }*/

}
