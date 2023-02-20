using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySpace;

public class SER : MyScript
{
    [SerializeField] AudioClip anvil;
    [SerializeField] AudioClip[] clashes;
    [SerializeField] AudioClip[] enjours;

    AudioSource _as;

    void Start()
    {
        _as = gameObject.GetComponent<AudioSource>();
    }

    public void Anvil()
    {
        _as.volume = .05f;
        _as.PlayOneShot(anvil);
    }

    public void Clashes()
    {
        _as.volume = .05f;
        _as.PlayOneShot(clashes[Randint(clashes.Length)]);
    }

    public void Enjours()
    {
        _as.volume = .1f;
        _as.PlayOneShot(enjours[Randint(enjours.Length)]);
    }

    new int Randint(int max) => UnityEngine.Random.Range(0, max);
}