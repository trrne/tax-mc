using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySpace;

public class HiyokoGenerator : MyScript
{
    [SerializeField] GameObject hiyoko;

    GameObject obj;

    void Start() => StartCoroutine(Gen());

    void Update() => Destroy(obj, 20);

    IEnumerator Gen()
    {
        while (true)
        {
            obj = Instantiate(hiyoko, transform.position, Quaternion.identity);

            var r = Randrange(5, 10);
            yield return new WaitForSeconds(r);
        }
    }
}
