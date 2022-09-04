using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection_7_1_2 : SelectionBalloon
{
    [SerializeField]
    private PrologueManager prologueManager;

    void Start()
    {

    }

    void Update()
    {

    }

    public override void First()
    {

    }
    public override void Second()
    {
        prologueManager.IncreaseOrder();
    }
}
