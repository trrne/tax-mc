using UnityEngine;

// dia 2 gold
// em 2 iron
public class ChangeBlock : MySpace.MyScript
{
    [SerializeField, Header("0: dia em, 1: gold iron")]
    Sprite[] blocks;

    SpriteRenderer sr;

    bool isStepped = true;

    void Start() => sr = this.gameObject.GetComponent<SpriteRenderer>();

    void Update()
    {
        if (isStepped)
            sr.sprite = blocks[0];

        else
            sr.sprite = blocks[1];
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag(Batch.Tags["Player"]))
        {
            isStepped = false;
            gameObject.tag = Batch.Tags["Gold"];
        }
    }
}
