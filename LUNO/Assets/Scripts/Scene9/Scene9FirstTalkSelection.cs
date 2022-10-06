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
        // 각 선택지를 선택했을 때 시행되어야 하는 내용 작성
        prologueManager.IncreaseOrder();
    }

    public override void Second()
    {
        prologueManager.IncreaseOrder();
    }
}