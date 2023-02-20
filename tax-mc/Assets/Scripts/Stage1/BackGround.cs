using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteAlways]
public class BackGround : MonoBehaviour
{
    [SerializeField] Sprite[] backgrounds;
    [SerializeField] GameObject clockObj;

    SpriteRenderer bgSr;
    ClockAnimation ca;

    const int Day = 0;
    const int Night = 1;

    void Start()
    {
        bgSr = gameObject.GetComponent<SpriteRenderer>();
        ca = clockObj.GetComponent<ClockAnimation>();

        Brighten();
    }

    void Update()
    {
        Cycle();

        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(Batch.Scenes["Title"]);
    }

    void Cycle()
    {
        if (ca.IsDay)
            Brighten();
        else
            Darken();
    }

    void Darken() => bgSr.sprite = backgrounds[Night];
    void Brighten() => bgSr.sprite = backgrounds[Day];
}
