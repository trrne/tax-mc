using UnityEngine;
using System.Collections.Generic;
using MySpace;

public class Batch : MyScript
{
    // 気分で辞書にしてみたけど補完きかんし一括で変えれんから最初のほうがよさそう
    // いちいち開いて確認すんのは時間の無駄
    public static Dictionary<string, string> Tags = new()
    {
        {"Player", "Cat"},
        {"Ladder", "Ladder"},
        {"JumpKey", "Jump"},
        {"Ground", "Ground"},
        {"Cp", "Checkpoint"},
        {"Slime", "Slime"},
        {"ClimbKey", "LadderV"},
        {"Obs", "Obstruct"},
        {"Water", "Water"},
        {"Booster", "Booster"},
        {"BackGround", "BackGround"},
        {"Portal", "Portal"},
        {"Teleport", "Teleport"},
        {"Tagging", "MAD"},
        {"Destroy", "Destroy"},
        {"Stage", "Stage"},
        {"Sprite", "Sprites"},
        {"Sound", "Sounds"},
        {"Other", "Others"},
        {"NotJumpArea", "CannotJump"},
        {"Safety", "SafetyArea"},
        {"Cannon", "Cannon"},
        {"Tarai", "Tarai"},
        {"ObjSafety", "ObjSafety"},
        {"Dia", "Checkpoint_diamond"},
        {"Gold", "Checkpoint_gold"},
        {"Spawning", "SpawnArea"},
    };

    public static Dictionary<string, string> Scenes = new()
    {
        {"Title", "Title"},
        {"Credit", "Credit"},
        {"1", "Stage1"},
        {"2", "Stage2"},
        {"Goal", "Congrats"},
    };
}
