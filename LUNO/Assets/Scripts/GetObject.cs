using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObject : MonoBehaviour
{
    // public bool Is어쩌구Hold = false;    << 나중의 이벤트 처리를 위한 변수(예시 : IsCupHold)
    private int getEvent = 0;
    public SpriteRenderer render; // 해당 아이템의 sprite를 집어넣는 곳
    Move move;

    void Start()
    {

        if (move == null)
        {
            if (GameObject.Find("Player_Night"))
                move = GameObject.Find("Player_Night").GetComponent<Move>();

            else if (GameObject.Find("Player"))
                move = GameObject.Find("Player").GetComponent<Move>();
        }
        // render = GameObject.Find("없어져야할 스프라이트 오브젝트").GetComponent<SpriteRenderer>(); << 수정해서 활성화 해주세요
    }

    // Update is called once per frame
    void Update()
    {
        if(getEvent == 1) // 이 이벤트가 끝났을 때
        {
            Invoke("RenderDisAppear", 1.0f);
        }

    }

    void RenderDisAppear() // 스프라이트 없애주는 함수
    {
        render.enabled = false;
        getEvent = 2;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E) && getEvent == 0)
            {
                //Is어쩌구Hold = true;
                move.isOn = false;
                move.IsHand = true;// 해당 아이템의 sprite를 집어넣는 곳
                getEvent = 1;
            }
        }
    }

}
