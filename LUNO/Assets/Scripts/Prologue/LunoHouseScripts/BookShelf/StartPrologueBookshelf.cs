using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPrologueBookshelf : MonoBehaviour
{
    [SerializeField]
    private PrologueManager prologueManager;
    Move move;

    // Start is called before the first frame update
    void Start()
    {
        move = GameObject.Find("Player_Night").GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                move.isOn = false;
                if (prologueManager.GetDone())     /**/
                    prologueManager.ResetOrder(); /**/
                prologueManager.StartPrologue();
            }
        }
    }
}
