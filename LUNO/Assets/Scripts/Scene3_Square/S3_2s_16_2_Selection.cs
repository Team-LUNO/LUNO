using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S3_2s_16_2_Selection : SelectionBalloon
{
    [SerializeField]
    private DialogueManager dialogueManager;

    [SerializeField]
    private VillageDaytimeManager villageDaytimeManager;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public override void First()
    {
        //Cosmos
        villageDaytimeManager.item[1].SetActive(true);
        MoveOnScene4();
    }

    public override void Second()
    {
        //Rose
        villageDaytimeManager.item[2].SetActive(true);
        MoveOnScene4();
    }

    public override void Third()
    {
        //Lily
        villageDaytimeManager.item[3].SetActive(true);
        MoveOnScene4();
    }

    public void MoveOnScene4()
    {
        //sound: item_get
        villageDaytimeManager.item[0].SetActive(true);
        villageDaytimeManager.sceneNum = 4;
        villageDaytimeManager.Scene4Setting();
        dialogueManager.IncreaseOrder();
    }
}
