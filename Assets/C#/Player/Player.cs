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

    public float dodgeDuration = 1f;
    public float boostSpeed = 10f;

    private bool isOneSide;

    public bool isRun = false;
    public bool CanRun = true;
    public bool isDeath = false;
    private bool isSliding = false;
    private bool isDodging = false;
    private bool isBoosting = false;
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
            if (!isDodging)
            {
                if (CanRun && !isRun)
                {
                    RightRun();
                }

                Jump();
                CheckGround();
                oneSideCheck();

                if (!isSliding)
                {
                    Slide();
                }
                Boost();
            }

            Dodge();
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

    //正常向右奔跑
    void RightRun()
    {
        //动画
        Vector2 playerVel = new Vector2(runSpeed, myRb2D.velocity.y);
        myRb2D.velocity = playerVel;
        //isRun = true;
    }

    //加速向右奔跑
    void Boost()
    {
       
        if (Input.GetKeyDown(KeyCode.D) && !isBoosting) 
        {
            //动画
            isBoosting = true;
            runSpeed = boostSpeed;
        }

        if (Input.GetKeyUp(KeyCode.D) && isBoosting)
        {
            //动画结束
            isBoosting = false;
            runSpeed = 5f;
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
    /*void Filp()//翻转
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
    }*/


    /*
     * 三个主要技能 *
     */

    //跳跃技能
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W))
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

    //滑行技能
    void Slide()
    {
        if (Input.GetKeyDown(KeyCode.S) && !isSliding && isGround)
        {
            isSliding = true;

            //滑行动画启动  待补充

        }

        if (Input.GetKeyUp(KeyCode.S) && isSliding)
        {
            isSliding = false;

            // 退出滑行动画  待补充

        }
    }

    //躲避技能
    void Dodge()
    {
        if (Input.GetKeyDown(KeyCode.A) && !isDodging && isGround)
        {
            StartCoroutine(DodgeCoroutine());
        }
    }
    IEnumerator DodgeCoroutine()
    {
        isDodging = true;

        //切换到闪躲动画 待补充

        float currentSpeed = myRb2D.velocity.x;

        myRb2D.velocity = new Vector2(currentSpeed, myRb2D.velocity.y);
        //闪烁无敌
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        if (sr == null)
        {
            Debug.LogError("SpriteRenderer 未找到，无法进行闪烁");
            yield break;
        }

        Debug.Log("开始闪烁");

        for (int i = 0; i < 3; i++)
        {
            Debug.Log("闪烁第" + (i + 1) + "次");
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.2f); //透明
            yield return new WaitForSeconds(0.1f);
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f); //不透明
            yield return new WaitForSeconds(0.1f);
        }

        //关闭闪烁动画
        isDodging = false;
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
