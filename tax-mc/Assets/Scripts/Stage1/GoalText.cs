using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class GoalText : Batch
{
    [SerializeField] GameObject text;

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag(Tags["Player"]))
            text.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D c)
    {
        if (c.CompareTag(Tags["Player"]))
            text.SetActive(false);
    }
}

