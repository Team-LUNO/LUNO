using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Move : MonoBehaviour
{
    public float maxSpeed = 3.5f;
    public float jumpPower;
    public float jumpTimeLimit = 0.1f;
    public bool walkMode;
    public bool ladderMode;
    public float ladderSpeed = 5f;

    public Animator rWalk;
    public Animator rRun;
    public Animator lWalk;
    public Animator lRun;
    public Animator climb;

    private float gravity;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        gravity = rigid.gravityScale;
    }

    private void FixedUpdate()
    {
        if (ladderMode)
        {
            if (Input.GetButton("Vertical"))
            {
                anim.enabled = true;
            }
            else
            {
                anim.enabled = false;
            }
            float v = Input.GetAxis("Vertical");
            rigid.gravityScale = 0;
            rigid.velocity = new Vector2(rigid.velocity.x, v * ladderSpeed);
        }
        else
        {
            //Move
            rigid.gravityScale = gravity;
            float h = Input.GetAxis("Horizontal");
            rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

            //Stop Speed
            if (Input.GetButtonUp("Horizontal"))
            {
                rigid.velocity
                    = new Vector2(rigid.velocity.normalized.x * 0.000000001f, rigid.velocity.y);
            }

            //max speed
            if (rigid.velocity.x > maxSpeed)
            {
                rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
            }
            else if (rigid.velocity.x < maxSpeed * (-1))
            {
                rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
            }

            //Jump
            if (Input.GetButtonDown("Jump") && !anim.GetBool("IsJump"))
            {
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                anim.SetBool("IsJump", true);
            }

            //after jump
            if (rigid.velocity.y < 0)
            {
                Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
                RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 5f, LayerMask.GetMask("platform"));

                if (rayHit.collider != null)
                {
                    if (rayHit.distance < 0.5f)
                        anim.SetBool("IsJump", false);
                }
            }

            //Animations
            if (Input.GetButtonDown("Horizontal"))
            {
                //spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
                if (Input.GetAxisRaw("Horizontal") == 1)
                {
                    if (walkMode)
                    {
                        anim.runtimeAnimatorController = rWalk.runtimeAnimatorController;
                    }
                    else
                    {
                        anim.runtimeAnimatorController = rRun.runtimeAnimatorController;
                    }
                }
                else if (Input.GetAxisRaw("Horizontal") == -1)
                {
                    if (walkMode)
                    {
                        anim.runtimeAnimatorController = lWalk.runtimeAnimatorController;
                    }
                    else
                    {
                        anim.runtimeAnimatorController = lRun.runtimeAnimatorController;
                    }
                }
            }

            if (Mathf.Abs(rigid.velocity.x) < 0.3)
            {
                anim.SetBool("IsWalk", false);
            }
            else
            {
                anim.SetBool("IsWalk", true);
            }

            //Walk & Run change
            if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (walkMode)
                {
                    walkMode = false;
                    maxSpeed = 6.0f;

                    if (anim.runtimeAnimatorController == rWalk.runtimeAnimatorController)
                        anim.runtimeAnimatorController = rRun.runtimeAnimatorController;
                    else if (anim == lWalk)
                        anim.runtimeAnimatorController = lRun.runtimeAnimatorController;
                }
                else
                {
                    walkMode = true;
                    maxSpeed = 3.5f;

                    if (anim.runtimeAnimatorController == rRun.runtimeAnimatorController)
                        anim.runtimeAnimatorController = rWalk.runtimeAnimatorController;
                    else if (anim == lRun)
                        anim.runtimeAnimatorController = lWalk.runtimeAnimatorController;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))
        {
            anim.runtimeAnimatorController = climb.runtimeAnimatorController;
            ladderMode = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            anim.enabled = true;
            anim.runtimeAnimatorController = rWalk.runtimeAnimatorController;
            ladderMode = false;
        }
    }
}