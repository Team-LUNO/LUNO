using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hasFruitSelection : SelectionBalloon
{
    [SerializeField]
    DialogueManager dialogueManager;

    [SerializeField]
    Scene3_SquareManager UIManager;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public override void First()
    {
        UIManager.item[0].SetActive(false);
        UIManager.getItem();
    }

    public override void Second()
    {
        //no change
    }
}
