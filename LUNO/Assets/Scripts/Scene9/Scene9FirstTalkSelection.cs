using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene9FirstTalkSelection : SelectionBalloon
{
    [SerializeField]
    private PrologueManager prologueManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void First()
    {
        // �� �������� �������� �� ����Ǿ�� �ϴ� ���� �ۼ�
        prologueManager.IncreaseOrder();
    }

    public override void Second()
    {
        prologueManager.IncreaseOrder();
    }
}