using UnityEngine;
using UnityEngine.SceneManagement;

using static UnityEngine.Device.Application;

public class Scenes : MonoBehaviour
{
    public void Title() => SceneManager.LoadScene(Batch.Scenes["Title"]);
    public void Game() => SceneManager.LoadScene(Batch.Tags["Stage"] + "1");
    public void Credit() => SceneManager.LoadScene(Batch.Scenes["Credit"]);
    public void AppExit() => Quit();
}
