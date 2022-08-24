using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinTalkSelection1 : SelectionBalloon
{
    [SerializeField]
    private PrologueManager prologueManager;
    Move move;

    // Start is called before the first frame update
    void Awake()
    {
        if (move == null)
        {
            if (GameObject.Find("Player_Night"))
                move = GameObject.Find("Player_Night").GetComponent<Move>();

            else if (GameObject.Find("Player"))
                move = GameObject.Find("Player").GetComponent<Move>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void First()
    {

    }

    public override void Second()
    {

    }
}