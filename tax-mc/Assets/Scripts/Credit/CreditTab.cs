using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditTab : MySpace.MyScript
{
    [SerializeField] LayerMask uiLayer = 1 << 11;

    [SerializeField] AudioClip clicks;
    [SerializeField] GameObject spriteBody;
    [SerializeField] GameObject soundBody;
    [SerializeField] GameObject otherBody;
    [SerializeField] GameObject button;

    AudioSource spk;

    SpriteRenderer spriteSr;
    SpriteRenderer soundSr;
    SpriteRenderer otherSr;

    bool click;

    string objTag;
    GameObject obj;

    void Start()
    {
        spk = GetComponent<AudioSource>();
        Activate(true, false, false, false, 0);
    }

    void Update()
    {
        FollowCursor();
        Tabs();

        if (Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene(Batch.Scenes["Title"]);

        // Debug.Log($"{spriteBody.activeSelf}{soundBody.activeSelf}{otherBody.activeSelf}");
    }

    void Tabs()
    {
        // MyScriptのGetGameObjectで取得できなかったからコピペ
        // https://kan-kikuchi.hatenablog.com/entry/RayCast4
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D h = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, 10, uiLayer);

        click = h.collider && Input.GetMouseButtonDown(0);
        if (click)
        {
            objTag = h.collider.tag;

            if (Obj("Sprite"))
                Activate(true, false, false, false);

            else if (Obj("Sound"))
                Activate(false, true, false, false);

            else if (Obj("Other"))
                Activate(false, false, true, true);
        }
    }

    void Activate(bool _sprite, bool _sound, bool _other, bool _button, float v = .5f)
    {
        spk.volume = v;
        spk.PlayOneShot(clicks);

        spriteBody.SetActive(_sprite);
        soundBody.SetActive(_sound);
        otherBody.SetActive(_other);
        button.SetActive(_button);
    }

    bool Obj(string str) => Batch.Tags[str] == objTag;
}
