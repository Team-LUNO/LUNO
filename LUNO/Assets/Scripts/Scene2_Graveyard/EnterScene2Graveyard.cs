using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterScene2Graveyard : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Animator lWalk;

    [SerializeField]
    private Vector3 movePosition;

    [SerializeField]
    private BoxCollider2D sceneMovementTrigger;

    private bool isWalking = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isWalking)
        {
            WalkIn();
        }
    }

    private void WalkIn()
    {
        player.GetComponent<Move>().enabled = false;
        Animator anim = player.GetComponent<Animator>();
        anim.runtimeAnimatorController
            = lWalk.runtimeAnimatorController;
        anim.SetBool("IsWalk", true);

        float speed = 2f;
        float distance = Vector3.Distance(movePosition, player.transform.position);

        if (distance > 0.1f)
        {
            player.transform.position
                    = Vector3.MoveTowards(player.transform.position, movePosition, speed * Time.deltaTime);
        }
        else
        {
            player.GetComponent<Move>().enabled = true;
            isWalking = false;
            sceneMovementTrigger.enabled = true;
        }
    }
}
