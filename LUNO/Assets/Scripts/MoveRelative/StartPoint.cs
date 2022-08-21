using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StartPoint : MonoBehaviour
{
    public string startPoint;
    private Move move;
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
        if (startPoint == move.currentMapName)
        {
            move.transform.position = transform.position;
        }
    }
}