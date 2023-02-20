using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadDatas : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField] Text t;


    void _Start()
    {
        Checkpoint pcp = player.GetComponent<Checkpoint>();
        SaveData.Datas datas = SaveManager.LoadData();

        Vector2 tp = player.transform.position;
        (tp.x, tp.y) = datas.pos;

        Vector2 cp = pcp.respawnPos;
        (cp.x, cp.y) = datas.cp;

        t.text = $"px: {tp.x}, py: {tp.y}\ncx: {cp.x}, cy: {cp.y}";
        print("loaded");
    }
}