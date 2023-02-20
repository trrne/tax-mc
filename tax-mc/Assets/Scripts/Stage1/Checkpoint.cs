using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MySpace;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] GameObject fx;
    [SerializeField] SER ser;

    public Vector2 respawnPos = new(-10.5f, 1.36f);
    public Vector2 RespawnPos => respawnPos;

    const float Dist = 1.35875f;

    bool spawn = false;

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag(Batch.Tags["Obs"]))
        {
            III();
            ser.Enjours();

            transform.position = respawnPos;
        }
    }

    void OnTriggerStay2D(Collider2D c)
    {
        if (c.CompareTag(Batch.Tags["Spawning"]))
            spawn = true;
    }

    void OnTriggerExit2D(Collider2D c)
    {
        if (c.CompareTag(Batch.Tags["Spawning"]))
            spawn = false;
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag(Batch.Tags["Tagging"]))
        {
            III();
            transform.position = respawnPos;
        }

        if (c.gameObject.tag.Contains(Batch.Tags["Cp"]))
        {
            var cp = c.gameObject.transform.position;
            //! Mathf.Roundだと桁数を丸められないからSystem.~
            respawnPos = new(Mathf.Round(cp.x), MathF.Round(cp.y + Dist, 2));

            if (c.gameObject.CompareTag(Batch.Tags["Dia"]))
                ser.Anvil();
        }

        if (c.gameObject.CompareTag(Batch.Tags["Tagging"]))
            ser.Clashes();

        if (c.gameObject.CompareTag(Batch.Tags["Teleport"]))
            SceneManager.LoadScene("Stage2");
    }

    void III()
    {
        var a = MyScript.Ins(fx, transform.position, Quaternion.identity);
        Destroy(a, .3f);
    }
}
