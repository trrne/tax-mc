using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySpace;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MyScript
{
    [SerializeField] AudioClip[] musics;
    [SerializeField] Text playing;

    AudioSource spk;

    string song;

    int index = 0;
    float vol = .05f;
    float volCtrl = .01f;

    bool next;
    bool vUp, vDown;

    string[] play = {
        "Now playing...",
        "Now playing..",
        "Now playing.",
    };

    void Start()
    {
        spk = this.gameObject.GetComponent<AudioSource>();
        spk.Play();

        StartCoroutine(Texts());
    }

    void Update()
    {
        Def();
        BGM();
    }

    void BGM()
    {
        song = musics[index].name;

        if (next || !spk.isPlaying)
        {
            index = Randint(musics.Length);
            spk.clip = musics[index];
            spk.Play();
        }

        if (vUp) vol += volCtrl;
        if (vDown) vol -= volCtrl;

        spk.volume = vol;
    }

    IEnumerator Texts()
    {

        float aa = 1;
        while (true)
        {
            //* 超コードクローン
            playing.text = $"{play[0]} {song}";
            yield return new WaitForSeconds(aa * 2);

            playing.text = $"{play[1]} {song}";
            yield return new WaitForSeconds(aa);

            playing.text = $"{play[2]} {song}";
            yield return new WaitForSeconds(aa);

            playing.text = $"{play[1]} {song}";
            yield return new WaitForSeconds(aa);
        }
    }

    void Def()
    {
        next = Input.GetKeyDown(KeyCode.LeftArrow);
        vUp = Input.GetKeyDown(KeyCode.UpArrow);
        vDown = Input.GetKeyDown(KeyCode.DownArrow);
    }
}
