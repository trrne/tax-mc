using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : Batch
{
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag(Tags["Player"]))
        {
            var sceneName = SceneManager.GetActiveScene().name;
            var num = int.Parse(sceneName.Replace(Tags["StageScene"], ""));

            SceneManager.LoadScene(Tags["StageScene"] + (num + 1));
        }
    }
}
