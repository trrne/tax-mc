using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using MySpace;

public class Opening : MonoBehaviour
{
    public enum URL
    {
        SpritersResource = 0,
        ResourcePacks = 1,
        PngTree = 2,
        Piyotaso = 3,
        IllustAC = 4,
        SEDL = 5,
        MusicBee = 6,
        Unity = 7,
        Github = 8,
        Gimp = 9,
        VSCode = 10,
        Credit = 11
    }
    [SerializeField] URL url = 0;

    void Update()
    {
        Debug.Log(url);
    }
}