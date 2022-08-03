using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RopeInteraction : MonoBehaviour
{
    public GameObject bubble;   //EŰ�� �����ϴ� UI
    public GameObject rope;
    public GameObject ropeFinish;
    public bool ropeOnSwitch = false;   //��ٸ��� ������ �Ǵ� ��Ȳ���� �Ǵ��ϴ� bool
    public bool ropeOffSwitch = false;  //��ٸ��� ��� �Ǵ� ��Ȳ����

    void Update()
    {
        if (ropeOnSwitch == true && Input.GetKeyDown(KeyCode.E))
        {
            if (bubble.activeSelf == true)
            {
                bubble.SetActive(false);
            }
            rope.SetActive(true);
            ropeFinish.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //��ٸ��� ���� �� �ִ� ������ ������
        if (collision.gameObject.CompareTag("Rope1") && !ropeOnSwitch && !rope.activeSelf)
        {
            bubble.SetActive(true); //EŰ bubble Ȱ��ȭ
            ropeOnSwitch = true;
        }

        //��ٸ� �ڵ� ���� ����
        if (collision.gameObject.CompareTag("RopeFinish") && ropeOffSwitch)
        {
            rope.SetActive(false);
            ropeOffSwitch = false;
        }

        //��ٸ��� ������
        if(collision.gameObject.CompareTag("Rope2"))
        {
            ropeOffSwitch = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //��ٸ��� ���� �� �ִ� �������� �����
        if (collision.gameObject.CompareTag("Rope1"))
        {
            bubble.SetActive(false);
            ropeOnSwitch = false;
        }
    }
}
