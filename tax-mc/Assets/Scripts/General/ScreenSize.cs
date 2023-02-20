using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenSize : MySpace.MyScript
{
    bool isFull = true;

    void Start()
    {
        Screen.fullScreen = true;
        TransparentCursor(true);
    }

    void Update()
    {
        isFull = Screen.fullScreen == true;
        // toggle f11
        if (Input.GetKeyDown(KeyCode.F11))
        {
            if (isFull) Screen.fullScreen = false;
            else Screen.fullScreen = true;
        }

        if (Input.GetKeyDown(KeyCode.F1)) SceneManager.LoadScene(0);
        if (Input.GetKeyDown(KeyCode.F2)) SceneManager.LoadScene(1);
        if (Input.GetKeyDown(KeyCode.F3)) SceneManager.LoadScene(2);
    }
}
