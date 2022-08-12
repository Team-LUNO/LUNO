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

        //�����̽��ٸ� ��� �������� �ƴ��� �Ǻ�
        if (Input.GetKey(KeyCode.Space))
        {
            isLongJump = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isLongJump = false;
        }


        // ĳ���� �̹��� �¿����
        if (Input.GetButtonDown("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }


        //�ȴ¸��, ����Ʈ����� ��ȯ
        if (Mathf.Abs(rigid2D.velocity.x) < 0.3)
        {
            anim.SetBool("IsWalk", false);
        }
        else
        {
            anim.SetBool("IsWalk", true);
        }

        // �޸���, �ȱ� ��� ��ȯ
        if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (walkMode)// walkMode�� true�϶��� �ȱ�, false�϶��� �޸���(����Ʈ�� �ȱ�� �Ǿ� ����)
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

        //�����̽��� ��Դ�������/ª�� �������� ���� ��������
        if (isLongJump && rigid2D.velocity.y > 0)
        {
            rigid2D.gravityScale = 1.0f;
        }
        else
        {
            rigid2D.gravityScale = 2.5f;
        }


        if (rigid2D.velocity.y < 0) // ���� ��Ҵ��� �� ��Ҵ��� �Ǻ��ϴ� �ڵ�
        {
            Debug.DrawRay(rigid2D.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rigid2D.position, Vector3.down, 1, LayerMask.GetMask("platform"));

            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.5f)
                    anim.SetBool("IsJump", false);
            }
        }


        //��ٸ� Ÿ�� �ڵ�
        if (IsLadder)
        {
            float ver = Input.GetAxis("Vertical");
            rigid2D.gravityScale = 0.0f;
            rigid2D.velocity = new Vector2(rigid2D.velocity.x, ver * speed);

        }
        else //ad�� �����̱� ���. ��ٸ� Ÿ�� �ö󰡰ų� �������� ���� ���� ������ �����̱� �Ұ���.
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

    //�浹�� �����Ͽ� ��ٸ�Ÿ�� �������� �ƴ��� �Ǵ�
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        { // ��ٸ� ��� ���·� ��ȯ
            IsLadder = true;
        }


        // ��ٸ��� �� �ö��� �ʰ� �ߵ��� ������ ���, ������ ������ �� �ְ� ���ִ� ��
        RaycastHit2D rayHit = Physics2D.Raycast(rigid2D.position, Vector3.down, 1, LayerMask.GetMask("platform"));

        if (Input.GetKey(KeyCode.S) && rayHit.collider != null)
        {
            Debug.Log("connect");
            IsLadder = false;
        } 
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ladder")) // ��ٸ����� ����� ��ٸ� Ÿ�� ���¿��� ���
        {
                IsLadder = false;
        }

    }
}
