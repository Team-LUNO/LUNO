using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSap : MonoBehaviour
{

    public bool IsSapHold = false;
    public int getEvent = 0;
    public SpriteRenderer render; // 해당 아이템의 sprite를 집어넣는 곳
    Move move;
    UIManager uiManager;
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
        render = GameObject.Find("mountain_sap").GetComponent<SpriteRenderer>();
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (getEvent == 1) // 컵을 들고있는지 아닌지(컵 스프라이트 숨기기/보이기 조정)
        {
            Invoke("RenderDisAppear", 1.0f);
        }

    }

    void RenderDisAppear()
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
                IsSapHold = true;
                uiManager.hasItem = true;
                move.isOn = false;
                move.IsHand = true;
                getEvent = 1; // 딱 한번만 이벤트 발생
            }
        }
    }

}
