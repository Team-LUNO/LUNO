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
    public string currentMapName;
    public string arriveStartPoint;
    private float Gravity;
    private Rigidbody2D rigid2D;
    public Sprite ladderSprite;
    SpriteRenderer spriteRenderer;
    Animator anim;

    public Animator rWalk;
    public Animator rRun;
    public Animator lWalk;
    public Animator lRun;


    public bool isOn;



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
        DontDestroyOnLoad(gameObject);
        isOn = true;
    }


    void Update()
    {
        if (isOn)
        {
            float Scale = transform.localScale.x;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }


            //�����̽��ٸ� ��� �������� �ƴ��� �Ǻ�
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

            //������ȯ
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
                else if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.A))
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

            //�����̽��� ��Դ�������/ª�� �������� ���� ��������
            if (isLongJump && rigid2D.velocity.y > 0)
            {
                rigid2D.gravityScale = 1.0f;
            }
            else
            {
                rigid2D.gravityScale = 2.5f;
            }

            //��ٸ�Ÿ��
            if (IsLadder)
            {
                RaycastHit2D rayHit1 = Physics2D.Raycast(rigid2D.position, Vector3.down, 2f * Scale, LayerMask.GetMask("platform"));
                rigid2D.gravityScale = 0;
                if (ladderMode)
                {
                    if (Input.GetButton("Vertical") && rayHit1.collider == null) // ���� �÷����� �հ� �ִϸ��̼� ���;� �ϱ� ������
                    {
                        anim.enabled = true;
                        anim.SetBool("IsClimb", true);
                    }
                    else
                    {
                        anim.enabled = false;
                    }
                    spriteRenderer.sprite = ladderSprite;
                    float ver = Input.GetAxis("Vertical");
                    rigid2D.velocity = new Vector2(rigid2D.velocity.x, ver * speed);

                }

            }
            else //ad�� �����̱� ���. ��ٸ� Ÿ�� �ö󰡰ų� �������� ���� ���� ������ �����̱� �Ұ���.
            {
                anim.enabled = true;
                anim.SetBool("IsClimb", false);
                rigid2D.gravityScale = Gravity;
                float x = Input.GetAxisRaw("Horizontal");
                move(x);
            }
        }

    }


    // Update is called once per frame
    void FixedUpdate()
    {

        if (isOn)
        {
            float Scale = transform.localScale.x;

            if (rigid2D.velocity.y < 0) // ���� ��Ҵ��� �� ��Ҵ��� �Ǻ��ϴ� �ڵ�
            {
                Debug.DrawRay(rigid2D.position, Vector3.down, new Color(0, 1, 0));
                RaycastHit2D rayHit1 = Physics2D.Raycast(rigid2D.position, Vector3.down, 3 * Scale, LayerMask.GetMask("platform"));
                RaycastHit2D rayHit2 = Physics2D.Raycast(rigid2D.position, Vector3.down, 3 * Scale, LayerMask.GetMask("platform(ignore)"));

                if (rayHit1.collider != null || rayHit2.collider != null)
                {
                    if (rayHit1.distance < 3.75f * Scale || rayHit2.distance < 3.75f * Scale)
                        anim.SetBool("IsJump", false);
                }
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


    //�浹�� �����Ͽ� ��ٸ�Ÿ�� �������� �ƴ��� �Ǵ�
    public void OnTriggerStay2D(Collider2D collision)
    {
        float Scale = transform.localScale.x;

        // ��ٸ��� �� �ö��� �ʰ� �ߵ��� ������ ���, ������ ������ �� �ְ� ���ִ� ��
        RaycastHit2D rayHit1 = Physics2D.Raycast(rigid2D.position, Vector3.down, 3 * Scale, LayerMask.GetMask("platform"));
        RaycastHit2D rayHit2 = Physics2D.Raycast(rigid2D.position, Vector3.down, 3 * Scale, LayerMask.GetMask("platform(ignore)"));

        if (collision.gameObject.tag == "Ladder")
        {
            IsLadder = true;
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                ladderMode = true;

            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                if (rayHit1.collider != null || rayHit2.collider != null)
                {
                    IsLadder = false;
                    ladderMode = false;
                }

            }


        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder")) // ��ٸ����� ����� ��ٸ� Ÿ�� ���¿��� ���
        {
            IsLadder = false;
        }

    }


}