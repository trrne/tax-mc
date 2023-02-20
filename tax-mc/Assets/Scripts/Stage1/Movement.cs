using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : Batch
{
    protected SpriteRenderer sr;
    Rigidbody2D rb;
    Transform ascend;
    PlayerAnimation pa;

    const float BoostPower = 1024;
    const float MoveSpeed = 5;
    const float MovePower = 5; // for rb.velocity
    const float JumpPower = 280;
    const float StrengthJumpPower = JumpPower * 1.5f; // でかいジャンプ

    bool isFloating = false;
    bool isAscender = false;
    bool isBoostJumper = false;

    // プレイヤーの状態でアニメーション管理
    protected enum PlayerState { Idle, Walk, }
    PlayerState state = PlayerState.Idle;
    protected PlayerState State => state;

    Vector2 moveVel, moveDir;

    protected void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        sr = this.gameObject.GetComponent<SpriteRenderer>();
        pa = this.GetComponent<PlayerAnimation>();
    }

    void Update()
    {
        TransparentCursor();

        MoveETC();
        Jump();
    }

    // void Saving()
    // {
    //     if (SceneManager.GetActiveScene().name == Batch.Scenes["1"] && Input.GetKeyDown(KeyCode.Escape))
    //     {
    //         var a = pa.player.GetComponent<Checkpoint>();
    //         SaveData.Datas data = new((
    //                 this.transform.position.x,
    //                 this.transform.position.y
    //             ), (
    //                 a.RespawnPos.x,
    //                 a.RespawnPos.y
    //             )
    //         );
    //         SaveManager.Save(data);

    //         print("saved");
    //     }
    // }

    void FixedUpdate()
    {
        if (isAscender)
            rb.AddForce(ascend.up * BoostPower);
    }

    // ブロックの側面に引っかかって落下しなくなる -> 解決できなかったから廃棄
    void _RigMove() => rb.velocity = new(moveVel.x, rb.velocity.y);

    void MoveETC()
    {
        // var h = Input.GetAxisRaw("Horizontal");
        // moveDir = new(h, 0);
        // moveDir.Normalize();
        // moveVel = moveDir * MovePower;

        if (Input.GetKey(KeyCode.A))
            Move(true, Vector3.left);

        else if (Input.GetKey(KeyCode.D))
            Move(false, Vector3.right);

        else state = PlayerState.Idle;
    }

    void Move(bool _flip, Vector3 _v)
    {
        sr.flipX = _flip;
        state = PlayerState.Walk;

        transform.position += _v * MoveSpeed * Time.deltaTime;
    }

    void Jump()
    {
        if (Input.GetButton(Tags["JumpKey"]))
        {
            if (isBoostJumper)
            {
                isFloating = true;
                rb.AddForce(StrengthJumpPower * Vector2.up, ForceMode2D.Impulse);
                isBoostJumper = false;
            }

            else if (!isFloating)
            {
                isFloating = true;
                rb.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag(Tags["Ground"]))
            isFloating = false;

        if (c.gameObject.CompareTag(Tags["Slime"]))
            isBoostJumper = true;
    }

    void OnTriggerStay2D(Collider2D c)
    {
        if (c.CompareTag(Tags["Booster"]))
        {
            ascend = c.GetComponent<Transform>();
            isAscender = true;
        }
    }

    void OnTriggerExit2D(Collider2D c)
    {
        if (c.CompareTag(Tags["Booster"]))
        {
            ascend = null;
            isAscender = false;
        }
    }
}
