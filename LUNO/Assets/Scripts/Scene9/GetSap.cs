using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSap : MonoBehaviour
{

    public bool IsSapHold = false;
    public int SapEvent = 0;
    public SpriteRenderer SapRender;
    // Start is called before the first frame update
    void Start()
    {
        SapRender = GameObject.Find("mountain_sap").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SapEvent == 1) // ���� ����ִ��� �ƴ���(�� ��������Ʈ �����/���̱� ����)
        {
            SapRender.enabled = false;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E) && SapEvent == 0)
            {
                SapEvent = 1; // �� �ѹ��� �̺�Ʈ �߻�
                IsSapHold = true;
            }
        }
    }

}
