using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class HiyokoMovements : MonoBehaviour
{
    [SerializeField] AudioClip sound;

    Rigidbody2D rb;
    AudioSource spk;

    float speed = 10;

    void Start() => Get();

    void FixedUpdate() => Move();

    void Move()
    {
        rb.AddForce(Vector2.left * speed);
        spk.clip = sound;
        spk.Play();
    }

    void Get()
    {
        spk = GetComponent<AudioSource>();
        rb = this.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
    }
}
