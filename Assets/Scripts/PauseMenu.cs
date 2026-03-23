using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    private void Update()
    {
        if (GameIsPaused)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Resume()
    {
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }
}
