using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// for col
public class Gust : Batch
{
    [SerializeField] GameObject _;

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag(Tags["Player"]))
            _.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D c)
    {
        if (c.CompareTag(Tags["Player"]))
            _.SetActive(false);
    }
}
