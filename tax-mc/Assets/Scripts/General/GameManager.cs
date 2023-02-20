using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Batch
{
    const float playerMass = 60;
    const float gravity = 9.81f;

    GameObject player;
    Rigidbody2D playerRb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags["Player"]);
        playerRb = player.GetComponent<Rigidbody2D>();
        Physics2D.gravity = new(0, -gravity);
        playerRb.mass = playerMass;
    }


}
