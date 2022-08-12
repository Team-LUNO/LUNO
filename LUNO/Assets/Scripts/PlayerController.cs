using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float speed = 5.0f;
    private float jumpForce = 14.0f;
    public bool IsLadder;
    public bool walkMode;
    public bool ladderMode;
    public bool isLongJump = false;
    private float Gravity;
    private Rigidbody2D rigid2D;
    SpriteRenderer spriteRenderer;
    Animator anim;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        Gravity = rigid2D.gravityScale;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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


        // 캐릭터 이미지 좌우반전
        if (Input.GetButtonDown("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }


        //걷는모션, 디폴트모션의 전환
        if (Mathf.Abs(rigid2D.velocity.x) < 0.3)
        {
            anim.SetBool("IsWalk", false);
        }
        else
        {
            anim.SetBool("IsWalk", true);
        }

        // 달리기, 걷기 모드 전환
        if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (walkMode)// walkMode가 true일때는 걷기, false일때는 달리기(디폴트는 걷기로 되어 있음)
            {
                walkMode = false;
                speed = 5.0f;
            }
            else
            {
                walkMode = true;
                speed = 3.0f;
            }
        }

    }

    private void FixedUpdate()
    {

        //스페이스바 길게눌렀을때/짧게 눌렀을때 점프 강도조절
        if (isLongJump && rigid2D.velocity.y > 0)
        {
            rigid2D.gravityScale = 1.0f;
        }
        else
        {
            rigid2D.gravityScale = 2.5f;
        }


        if (rigid2D.velocity.y < 0) // 땅에 닿았는지 안 닿았는지 판별하는 코드
        {
            Debug.DrawRay(rigid2D.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rigid2D.position, Vector3.down, 1, LayerMask.GetMask("platform"));

            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.5f)
                    anim.SetBool("IsJump", false);
            }
        }


        //사다리 타는 코드
        if (IsLadder)
        {
            float ver = Input.GetAxis("Vertical");
            rigid2D.gravityScale = 0.0f;
            rigid2D.velocity = new Vector2(rigid2D.velocity.x, ver * speed);

        }
        else //ad로 움직이기 기능. 사다리 타고 올라가거나 내려가고 있을 때는 옆으로 움직이기 불가능.
        {
            rigid2D.gravityScale = Gravity;
            float x = Input.GetAxisRaw("Horizontal");
            Move(x);
        }
    }


    public void Move(float x)
    {
        rigid2D.velocity = new Vector2(x * speed, rigid2D.velocity.y);
    }


    public void Jump()
    {
        rigid2D.velocity = Vector2.up * jumpForce;
    }

    //충돌을 감지하여 사다리타기 가능한지 아닌지 판단
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        { // 사다리 사용 상태로 전환
            IsLadder = true;
        }


        // 사다리를 다 올라가지 않고 중도에 내려올 경우, 옆으로 움직일 수 있게 해주는 것
        RaycastHit2D rayHit = Physics2D.Raycast(rigid2D.position, Vector3.down, 1, LayerMask.GetMask("platform"));

        if (Input.GetKey(KeyCode.S) && rayHit.collider != null)
        {
            Debug.Log("connect");
            IsLadder = false;
        } 
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ladder")) // 사다리에서 벗어나면 사다리 타기 상태에서 벗어남
        {
                IsLadder = false;
        }

    }
}
