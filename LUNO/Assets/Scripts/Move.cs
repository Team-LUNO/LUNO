using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Move : MonoBehaviour
{

    private float DefaultWalkspeed = 7.0f;
    private float DefaultRunspeed = 12.0f;
    private float speed;
    private float jumpForce = 14.0f;
    private int playerLayer, ignoreLayer;
    public bool IsLadder;
    public bool walkMode;
    public bool ladderMode;
    public bool isLongJump = false;
    private float Gravity;
    private Rigidbody2D rigid2D;
    SpriteRenderer spriteRenderer;
    Animator anim;

    public Animator rWalk;
    public Animator rRun;
    public Animator lWalk;
    public Animator lRun;



    // Start is called before the first frame update
    void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        Gravity = rigid2D.gravityScale;
        playerLayer = LayerMask.NameToLayer("Player");
        ignoreLayer = LayerMask.NameToLayer("platform(ignore)");
        float Scale = transform.localScale.x;
        speed = DefaultWalkspeed * Scale;
    }


    void Update()
    {

        float Scale = transform.localScale.x;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }


        //스페이스바를 길게 눌렀는지 아닌지 판별
        if (Input.GetKey(KeyCode.Space))
        {
            isLongJump = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isLongJump = false;
        }


        if (Input.GetButtonUp("Horizontal"))
        {       //?????? ???? ?????? ????  
            rigid2D.velocity = new Vector2(rigid2D.velocity.normalized.x * 0.000000001f, rigid2D.velocity.y);
        }

        //방향전환
        if (Input.GetButtonDown("Horizontal"))
        {
            if (Input.GetKeyDown(KeyCode.D))
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
            else if(Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.A)) {
                if (walkMode)
                {
                    anim.runtimeAnimatorController = lWalk.runtimeAnimatorController;
                }
                else
                {
                    anim.runtimeAnimatorController = lRun.runtimeAnimatorController;
                }
            }

            if (Input.GetKeyDown(KeyCode.A))
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
            else if (Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.D))
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
        }


        //????????, ???????????? ????
        if (Mathf.Abs(rigid2D.velocity.x) < 0.3)
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
                speed = DefaultRunspeed * Scale;

                if (anim.runtimeAnimatorController == rWalk.runtimeAnimatorController)
                    anim.runtimeAnimatorController = rRun.runtimeAnimatorController;
                else if (anim == lWalk)
                    anim.runtimeAnimatorController = lRun.runtimeAnimatorController;
            }
            else
            {
                walkMode = true;
                speed = DefaultWalkspeed * Scale;

                if (anim.runtimeAnimatorController == rRun.runtimeAnimatorController)
                    anim.runtimeAnimatorController = rWalk.runtimeAnimatorController;
                else if (anim == lRun)
                    anim.runtimeAnimatorController = lWalk.runtimeAnimatorController;
            }
        }

        //스페이스바 길게눌렀을때/짧게 눌렀을때 점프 강도조절
        if (isLongJump && rigid2D.velocity.y > 0)
        {
            rigid2D.gravityScale = 1.0f;
        }
        else
        {
            rigid2D.gravityScale = 2.5f;
        }

        //사다리타기
        if (IsLadder)
        {
            rigid2D.gravityScale = 0;
            if (ladderMode)
            {
                float ver = Input.GetAxis("Vertical");
                rigid2D.velocity = new Vector2(rigid2D.velocity.x, ver * speed);
            }

        }
        else //ad로 움직이기 기능. 사다리 타고 올라가거나 내려가고 있을 때는 옆으로 움직이기 불가능.
        {
            rigid2D.gravityScale = Gravity;
            float x = Input.GetAxisRaw("Horizontal");
            move(x);
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        float Scale = transform.localScale.x;

        if (rigid2D.velocity.y < 0) // 땅에 닿았는지 안 닿았는지 판별하는 코드
        {
            Debug.DrawRay(rigid2D.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rigid2D.position, Vector3.down, 7.5f*Scale, LayerMask.GetMask("platform"));

            if (rayHit.collider != null)
            {
                if (rayHit.distance < 3.75f * Scale)
                    anim.SetBool("IsJump", false);
            }
        }


    }


    public void move(float x)
    {
        rigid2D.velocity = new Vector2(x * speed, rigid2D.velocity.y);
    }


    public void Jump()
    {
        float Scale = transform.localScale.x;
        if (Input.GetButtonDown("Jump") && !anim.GetBool("IsJump") && !IsLadder)
        {
            rigid2D.velocity = Vector2.up * jumpForce;
            anim.SetBool("IsJump", true);
        }

    }


    //충돌을 감지하여 사다리타기 가능한지 아닌지 판단
    public void OnTriggerStay2D(Collider2D collision)
    {
        float Scale = transform.localScale.x;

        // 사다리를 다 올라가지 않고 중도에 내려올 경우, 옆으로 움직일 수 있게 해주는 것
        RaycastHit2D rayHit = Physics2D.Raycast(rigid2D.position, Vector3.down, 3 * Scale, LayerMask.GetMask("platform"));

        if (collision.gameObject.tag == "Ladder")
        {
            IsLadder = true;
            if (Input.GetKey(KeyCode.W) ||Input.GetKey(KeyCode.S))
            {
                ladderMode = true;

            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                if (rayHit.collider != null)
                {
                    IsLadder = false;
                    ladderMode = false;
                }
          
            }
            

        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder")) // 사다리에서 벗어나면 사다리 타기 상태에서 벗어남
        {
            IsLadder = false;
        }

    }


}