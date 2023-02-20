using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySpace;

public class Gen : MyScript
{
    [SerializeField] GameObject[] obs;
    // [SerializeField] GameObject player;

    // bool spawn;

    void Start()
    {
        // spawn = player.GetComponent<Checkpoint>().spawn;

        StartCoroutine(Generator());
    }

    IEnumerator Generator()
    {
        while (true)
        {
            var r = Randrange(.2f, 2);
            Randins(obs, transform.position, Quaternion.identity);

            yield return new WaitForSeconds(r);
        }
    }
}