using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookshelfSelection1 : SelectionBalloon
{
    [SerializeField]
    private PrologueManager prologueManager;
    Move move;

    // Start is called before the first frame update
    void Awake()
    {
        move = GameObject.Find("Player_Night").GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void First()
    {
        
        prologueManager.IncreaseOrder();
        move.isOn = true;
    }

    public override void Second()
    {
        Debug.Log("å �ٽ� �б�");
        prologueManager.IncreaseOrder();
        move.isOn = true; // �ش� �κ��� ���߿� ����
    }
}
