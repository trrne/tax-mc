using System.Collections;
using UnityEngine;
using MySpace;

public class ChangeSprite : MyScript
{
    [SerializeField] Sprite[] thxs;

    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(Changes());
    }

    IEnumerator Changes()
    {
        while (true)
        {
            var r = Randint(thxs.Length);
            sr.sprite = thxs[r];

            var rnd = Randrange(.1f, .5f);
            yield return new WaitForSeconds(rnd);
        }
    }
}
