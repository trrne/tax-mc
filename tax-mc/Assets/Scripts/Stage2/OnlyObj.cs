using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyObj : Batch
{
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (!c.CompareTag(Tags["Player"]))
            Destroy(c.gameObject);
    }
}