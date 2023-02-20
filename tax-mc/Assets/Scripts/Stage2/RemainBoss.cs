using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RemainBoss : MySpace.MyScript
{
    [SerializeField] Text t;
    [SerializeField] GameObject player;

    static float remain = 10;

    void Update() => Timer();

    void Timer()
    {
        remain -= Time.deltaTime;
        t.text = MathF.Round(remain, 0).ToString();

        if (remain <= 0)
            SceneManager.LoadScene(Batch.Scenes["Goal"]);
    }

    public static float TimerReset() => remain = 10;
}