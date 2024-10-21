using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float runSpeed;
    public float jumpSpeed;
    public float jumpChance;
    private Rigidbody2D myRb2D;
    private BoxCollider2D myFeet;
    private Animator myAnim;
    private TrailRenderer myTrail;
    private bool isGround;

    private bool isOneSide;

    public bool isDeath = false;
    void Start()
    {
        myRb2D = GetComponent<Rigidbody2D>();
        //myAnim = GetComponent<Animator>();
        myFeet = GetComponent<BoxCollider2D>();
        myTrail = GetComponent<TrailRenderer>();
    }

    void Update()
    {
        if (!isDeath)
        {
            Run();
            Filp();
            Jump();
            CheckGround();
            oneSideCheck();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && jumpChance == 1)
        {
            if (myRb2D.velocity.y <= 0.1f)
            {
                CheckGround();
            }
        }
    }

    void CheckGround()//地面检测
    {
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")) || myFeet.IsTouchingLayers(LayerMask.GetMask("oneSideBoard"));
        isOneSide = myFeet.IsTouchingLayers(LayerMask.GetMask("oneSideBoard"));
        if (isGround)
        {
            if (myRb2D.velocity.y <= 0.1f)
            {
                jumpChance = 2;
            }

        }
    }

    void Filp()//翻转
    {
        bool playerXAxisSpeed = Mathf.Abs(myRb2D.velocity.x) > Mathf.Epsilon;
        if (playerXAxisSpeed)
        {
            if (myRb2D.velocity.x > 0.1f)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (myRb2D.velocity.x < -0.1f)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
    void Run()//移动
    {
        float moveDir = Input.GetAxis("Horizontal");
        Vector2 playerVel = new Vector2(moveDir * runSpeed, myRb2D.velocity.y);
        myRb2D.velocity = playerVel;
        //bool playerXAxisSpeed = Mathf.Abs(myRb2D.velocity.x) > Mathf.Epsilon;
        //myAnim.SetBool("Run", playerXAxisSpeed);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (jumpChance == 2)
            {
                isGround = false;
                jumpChance--;
                Vector2 jumpVel = new Vector2(0.0f, jumpSpeed);
                myRb2D.velocity = jumpVel * Vector2.up;
            }
            else if (jumpChance == 1)
            {
                jumpChance--;
                Vector2 jumpVel = new Vector2(0.0f, jumpSpeed);
                myRb2D.velocity = jumpVel * Vector2.up;
            }

        }
        if (jumpChance == 0)
        {
            if (myRb2D.velocity.y <= 0.0f)
            {
                //动画机待补全
            }
        }
        if (jumpChance == 1)
        {
            if (myRb2D.velocity.y <= 0.0f)
            {
                //动画机待补全
            }
        }


    }

    void oneSideCheck()//单向板检测
    {
        if (isGround && gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
        }
        float VecY = Input.GetAxis("Vertical");
        if (isOneSide && VecY <= -0.1f)
        {
            gameObject.layer = LayerMask.NameToLayer("oneSideBoard");
            Invoke(nameof(ResortPlayerLayer), 0.4f);
        }
    }
    void ResortPlayerLayer()
    {
        if (!isGround && gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
        }

    }
}
