using UnityEngine;

public class SinText : MonoBehaviour
{
    float sinx, cosy;

    private void Update() => transform.localScale = new(Mathf.Sin(Time.time), Mathf.Cos(Time.time));
}
