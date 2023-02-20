using System;
using System.Collections.Generic;
using UnityEngine;
using MySpace;

public class PlayerMovements : MyScript
{
    [SerializeField, Header("0: cannon, 1: tarai, 2: others")]
    AudioClip[] ses;
    [SerializeField] GameObject clashFx;

    Rigidbody2D rb;
    SpriteRenderer sr;
    AudioSource spk;

    Quaternion qi;
    Vector2 tp;
    Vector2 rv;
    Vector2 respawn = new(0, 1.1f);

    const float MOVE = 16;
    float chargingMove = MOVE / 2;

    bool isCharging = false;
    bool canFire = false;
    public bool CanFire => canFire;
    bool left, right;
    bool JumpKey, JumpKeyDown, JumpKeyUp;
    bool isFloat;

    float jump = 10;
    float jumpCharge = 0;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        sr = this.GetComponent<SpriteRenderer>();
        spk = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        Def();

        Jump();
        Move();
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");

        if (!isCharging)
            transform.Translate(new(h * MOVE * Time.deltaTime, 0));

        else if (isCharging)
            transform.Translate(new(h * chargingMove * Time.deltaTime, 0));
    }

    void Jump()
    {
        if (JumpKey)
        {
            jumpCharge += jump * Time.deltaTime;
        }

        if (isFloat) return;

        else if (JumpKeyUp && !isFloat)
        {
            rb.AddForce(Vector2.up * jumpCharge, ForceMode2D.Impulse);
            jumpCharge = 0;
            isFloat = true;
        }
    }

    void OnTriggerStay2D(Collider2D c)
    {
        if (c.CompareTag(Batch.Tags["Safety"]))
            canFire = false;
    }

    void OnTriggerExit2D(Collider2D c)
    {
        if (c.CompareTag(Batch.Tags["Safety"]))
            canFire = true;
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (isHitting(c, Batch.Tags["Ground"]))
            isFloat = false;

        if (isHitting(c, Batch.Tags["Cannon"]))
            Hit(0);

        else if (isHitting(c, Batch.Tags["Tarai"]))
            Hit(1);

        else if (isHitting(c, Batch.Tags["Tagging"]))
            Hit(2);

        if (c.gameObject.CompareTag(Batch.Tags["Tarai"]) || c.gameObject.CompareTag(Batch.Tags["Cannon"]))
            Destroy(c.gameObject);
    }

    bool isHitting(Collision2D c, string _tag) => c.gameObject.CompareTag(_tag);

    void Hit(int i)
    {
        RemainBoss.TimerReset();
        transform.position = respawn;
        spk.volume = .05f;
        spk.PlayOneShot(ses[i]);
        var fx = Ins(clashFx, tp, qi);
        Destroy(fx, .3f);
    }

    void Def()
    {
        tp = transform.position;
        qi = Quaternion.identity;

        transform.position = new(Mathf.Clamp(tp.x, -21.8f, 21.8f), Mathf.Clamp(tp.y, 1.02492f, 24));

        JumpKey = Input.GetKey(KeyCode.Space);
        JumpKeyDown = Input.GetKeyDown(KeyCode.Space);
        JumpKeyUp = Input.GetKeyUp(KeyCode.Space);
        left = Input.GetKeyDown(KeyCode.A);
        right = Input.GetKeyDown(KeyCode.D);

        jumpCharge = Mathf.Clamp(jumpCharge, 4, 20);

        isCharging = JumpKey;

        if (left) sr.flipX = true;
        if (right) sr.flipX = false;
    }

    void DEBUG()
    {
        print($"canFire Parent: {canFire}");
        // print("in safety");
        // print(isFloat);
    }
}
