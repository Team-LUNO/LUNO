using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupHold : MonoBehaviour
{

    public bool IsCupHold = false;
    private int CupEvent = 0;
    public SpriteRenderer Cuprender;
    // Start is called before the first frame update
    void Awake()
    {
        Cuprender = GameObject.Find("n.luno1f_cup").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsCupHold) // 컵을 들고있는지 아닌지(컵 스프라이트 숨기기/보이기 조정)
        {
            Cuprender.enabled = false;
            CupEvent += 1; // 딱 한번만 이벤트 발생
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E) && CupEvent == 0)
            {
                IsCupHold = true;
            }
        }
    }

}
