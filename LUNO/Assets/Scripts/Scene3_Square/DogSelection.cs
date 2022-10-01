using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogSelection : SelectionBalloon
{
    [SerializeField]
    DialogueManager dialogueManager;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public override void First()
    {
        dialogueManager.IncreaseOrder();
    }

    public override void Second()
    {
        dialogueManager.IncreaseOrder();
    }
}
