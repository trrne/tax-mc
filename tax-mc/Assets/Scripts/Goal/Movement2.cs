using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MySpace;

public class Movement2 : MyScript
{
    float move = 5;

    float rx, ry;
    const float g = 20;

    void Update()
    {
        // ChanG();

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector2 hv = new(h, v);
        transform.Translate(hv * move * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene("Title");
        }
    }

    void ChanG()
    {
        if (Input.anyKeyDown)
        {
            rx = Randrange(-g, g);
            ry = Randrange(-g, g);
        }
        Physics2D.gravity = new(rx, ry);
    }
}