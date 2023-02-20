using System;
using System.Collections;
using UnityEngine;
using MySpace;

[ExecuteAlways]
public class BlockAnimation : MyScript
{
    [SerializeField]
    Sprite[] sprites;

    public enum Blocks { clock, other, bonfire, }
    [SerializeField] Blocks blockType = Blocks.other;

    SpriteRenderer sr;

    float anims = 0.05f;

    void Start()
    {
        sr = this.gameObject.GetComponent<SpriteRenderer>();

        switch (blockType)
        {
            case Blocks.clock:
                anims = 0.03125f; // 1秒1周
                break;

            case Blocks.bonfire:
                anims = 0.1f;
                break;

            default:
                anims = 0.05f;
                break;
        }

        StartCoroutine(Animation(sprites, sr, anims));
    }

}
