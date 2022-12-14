using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Move : MonoBehaviour
{
    public float maxSpeed = 3.5f;
    public float jumpPower;
    public float jumpTimeLimit = 0.1f;
    public bool IsLadder;
    public bool walkMode;
    public bool ladderMode;

    public Animator rWalk;
    public Animator rRun;
    public Animator lWalk;
    public Animator lRun;

    private float Gravity;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    public bool isOn;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        Gravity = rigid.gravityScale;
        isOn = true;
    }


    void Update()
    {
        //Debug.Log(isOn);
        if (isOn)
        {
            //????
            if (Input.GetButtonDown("Jump") && !anim.GetBool("IsJump") && !IsLadder)
            {
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                anim.SetBool("IsJump", true);
            }


            if (Input.GetButtonUp("Horizontal"))
            {       //?????? ???? ?????? ????  
                rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.000000001f, rigid.velocity.y);
            }

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


            //????????, ???????????? ????
            if (Mathf.Abs(rigid.velocity.x) < 0.3)
            {
                anim.SetBool("IsWalk", false);
            }
            else
            {
                anim.SetBool("IsWalk", true);
            }

            // ??????, ???? ???? ????
            if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (walkMode)// walkMode?? true?????? ????, false?????? ??????(???????? ?????? ???? ????)
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
        else
        {
            if (anim.runtimeAnimatorController == rWalk.runtimeAnimatorController || anim.runtimeAnimatorController == rRun.runtimeAnimatorController
                || anim.runtimeAnimatorController == rWalk.runtimeAnimatorController || anim.runtimeAnimatorController == rRun.runtimeAnimatorController)
            {
                anim.SetBool("IsWalk", false);
            }
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (isOn)
        {
            //?????? ???? ????. 
            if (IsLadder && ladderMode)
            {
                float ver = Input.GetAxis("Vertical");
                rigid.gravityScale = 0.0f;
                rigid.velocity = new Vector2(rigid.velocity.x, ver * maxSpeed);

            }
            else //ad?? ???????? ????. ?????? ???? ?????????? ???????? ???? ???? ?????? ???????? ??????.
            {
                rigid.gravityScale = Gravity;
                float h = Input.GetAxis("Horizontal");
                rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
            }


            // ?????????? ???? ?????? ???????? ????
            if (rigid.velocity.x > maxSpeed)
            {
                rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
            }
            else if (rigid.velocity.x < maxSpeed * (-1))
            {
                rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
            }

            //????????(???????? ?????????)
            if (rigid.velocity.y < 0)
            {
                Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
                RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 5f, LayerMask.GetMask("platform"));

                if (rayHit.collider != null)
                {
                    if (rayHit.distance < 2f)
                        anim.SetBool("IsJump", false);
                }
            }
        }
    }


    //?????? ???????? ?????????? ???????? ?????? ????


    public void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        { // ???????? ???? ???????? W, S ???? ?????? ?????? ?????? ?????? ?? ???? ?? ???????? ?????? ?? ?????? ???? ????
            ladderMode = true;
            IsLadder = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ladder"))
        {
            ladderMode = false;
            IsLadder = false;
        }

    }


}