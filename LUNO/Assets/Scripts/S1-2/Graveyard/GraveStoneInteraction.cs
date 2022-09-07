using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveStoneInteraction : MonoBehaviour
{
    public Scene2_Graveyard_UIManager UIManager;

    int prologueIndex;

    [SerializeField]
    private PrologueManager[] prologues;

    void Start()
    {
        
    }

    void Update()
    {
        if (prologueIndex == 2)
        {
            prologueIndex = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GraveStone"))
        {
            if (prologues[prologueIndex].GetDone())
            {
                prologues[prologueIndex].ResetOrder();
            }
            prologues[prologueIndex].StartPrologue();
            prologueIndex++;
        }
    }
}
