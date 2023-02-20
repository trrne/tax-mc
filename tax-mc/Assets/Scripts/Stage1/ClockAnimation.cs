using System.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ClockAnimation : MonoBehaviour
{
    [SerializeField]
    Sprite[] clocks;

    GameObject clock;
    SpriteRenderer sr;

    int clockPattern = 0;
    const float DayCycleSpeed = 1f;

    public enum CyclePattern { Day, Night }
    CyclePattern dayCycle;
    public CyclePattern DayCycle => dayCycle; // enumもpublicに

    bool isDay;
    public bool IsDay => isDay;

    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine(Animate(clocks, sr, DayCycleSpeed));
    }

    void Update()
    {
        //? day 00 - 14, 48 - 64 / night 15 - 47 
        isDay = clockPattern <= 14 || clockPattern >= 48;
        if (isDay)
            dayCycle = CyclePattern.Day;
        else
            dayCycle = CyclePattern.Night;
    }

    IEnumerator Animate(Sprite[] s, SpriteRenderer sr, float anim)
    {
        while (true)
        {
            clockPattern = clockPattern >= s.Length - 1 ? 0 : clockPattern + 1;
            sr.sprite = s[clockPattern];
            yield return new WaitForSeconds(anim);
        }
    }
}
