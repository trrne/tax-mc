using UnityEngine;

public class CannonGen : Batch
{
    [SerializeField] AudioClip sound;
    [SerializeField] GameObject[] obstructs;
    [SerializeField] GameObject player;

    AudioSource spk;
    PlayerMovements pm;
    GameObject tarai_;
    Rigidbody2D taraiRb;

    Transform pt;
    Vector2 tp;
    Quaternion tr;

    float rotateRange;
    float power;

    bool cannonFire = false;

    void Start()
    {
        spk = this.GetComponent<AudioSource>();
        pm = player.GetComponent<PlayerMovements>();
    }

    void Update()
    {
        Def();

        Gen();
        Rot();
    }

    void Gen()
    {
        if (cannonFire)
        {
            tarai_ = Randins(obstructs, tp, tr);
            spk.volume = .05f;
            spk.PlayOneShot(sound);
            taraiRb = tarai_.GetComponent<Rigidbody2D>();
            taraiRb.AddForce(transform.up * power, ForceMode2D.Impulse);
        }
    }

    void Rot() => transform.Rotate(tr.x, tr.y, rotateRange);

    void Def()
    {
        tp = this.transform.position;
        tr = this.transform.rotation;
        pt = player.transform;

        rotateRange = Randrange(-70, 70);
        cannonFire = pm.CanFire;
        power = Randrange(8, 16);
    }

    void DEBUG()
    {
        // print(rotateRange);
        print(cannonFire);
        // print($"timer: {timer}");
        // print($"canFire Child: {canFire}");
        // print($"canFire: {pm.CanFire}, timer: {timer > regen}");
    }
}
