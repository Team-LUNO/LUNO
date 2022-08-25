using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    //public GameObject keyDescription;   //����Ű ����â
    public GameObject itemImage;    //��� ���� ������ �̹���

    //Animator descriptionAnim;   //����Ű ����â �ִϸ��̼�
    //public bool descriptionAct; //�� ���� ����ǰ��ϱ� ���� �÷���
    public bool playerMove; //�÷��̾� ������ ���� ����
    public bool hasItem;    //������ ���� ����

    Move move;

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

    void Update()
    {
        /*
        //����Ű ����â ����
        //����â�� �� ���� ����� ���� ���� && ����â�� ���� ��Ȱ��ȭ ���� && �ƹ�Ű�� ���� ��
        if (!descriptionAct && !keyDescription.gameObject.activeSelf && Input.anyKeyDown)
        {
            keyDescription.SetActive(true);
            move.isOn = false; //�÷��̾� �� �����̰�
        }

        //����Ű ����â �ݱ�
        //����â�� �� ���� ����� ���� ���� && ����â�� ���� Ȱ��ȭ ���� && Esc/QŰ�� ���� ��
        else if (!descriptionAct && keyDescription.gameObject.activeSelf
            && (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Q)))
        {
            descriptionAct = true;  //�� �� ����� ǥ��
            descriptionAnim.SetTrigger("disappear");
            move.isOn = true;
            StartCoroutine(DisappearDelay());
        }
        */

        //������ ���
        //�������� ������ ���� && ������ �̹����� ��Ȱ��ȭ ����
        if (hasItem && !itemImage.gameObject.activeSelf)
        {
            Invoke("ShowIcon", 1f);
        }
        //�������� ������ ���� && ������ �̹����� Ȱ��ȭ ���� && EŰ ���� ��
        /*else if (hasItem && itemImage.gameObject.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            itemImage.SetActive(false);
            hasItem = false;
            Debug.Log("������ ���");
        }*/
    }


    void ShowIcon()
    {
        itemImage.SetActive(true);
    }
    //�ִϸ��̼� ���� �Ŀ� â�� �������� ������ ����
    /*IEnumerator DisappearDelay()
    {
        yield return new WaitForSecondsRealtime(0.75f);
        keyDescription.SetActive(false);
        Debug.Log("����Ű ����â ����");
    }*/
}
