using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene5StartPrologue : MonoBehaviour
{

    public PrologueManager prologueManager;
    private int Scene5Event; // �� �̺�Ʈ�� �ݺ��� ���� ���� ����
    Move move;
    // Start is called before the first frame update
    void Start()
    {
        move = GameObject.Find("Player_Night").GetComponent<Move>();
        Scene5Event = 0;
        move.isOn = false;
        Invoke("StartEvent", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Scene5Event == 1)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                prologueManager.IncreaseOrder();
                print("�̵�����");
                move.isOn = true;
                Scene5Event += 1;
            }
        }

    }

    void StartEvent()
    {
        if (Scene5Event == 0)
        prologueManager.StartPrologue();
        Scene5Event += 1;

    }
}
