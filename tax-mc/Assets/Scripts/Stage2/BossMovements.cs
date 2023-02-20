using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySpace;

public class BossMovements : MyScript
{
    [SerializeField] GameObject player;

    Quaternion tr;
    float rr;

    void Update()
    {
        Def();
        LookAtPlayer();
    }

    void LookAtPlayer() => transform.Rotate(tr.x, tr.y + rr, tr.z);

    void Def()
    {
        tr = transform.rotation;
        rr = player.transform.position.x;
    }
}
