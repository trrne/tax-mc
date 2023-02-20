using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySpace;

public class Gener : MyScript
{
    [SerializeField] GameObject[] objs;
    [SerializeField] List<GameObject> objsList;
    GameObject obj;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            var r = Randint(360);
            var q = Quaternion.Euler(0, 0, r);
            var tx = Randrange(-20, 20);
            var ty = Randrange(1, 23);
            obj = Randins(objs, new(tx, ty), q);
            objsList.Add(obj);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            foreach (var i in objsList)
            {
                Destroy(i);
            }

            objsList?.Clear();
        }
    }
}
