using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class SceneReset : Batch
{
    void Start()
    {
        this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        // 当たったらシーンリセット
        if (c.CompareTag(Tags["Player"]))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
