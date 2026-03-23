using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public PauseMenu pauseMenu;

    private void Start()
    {
        pauseMenu.Resume();
    }

    public void LoadSceneMain()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadSceneGame()
    {
        SceneManager.LoadScene("Game");
    }
}
