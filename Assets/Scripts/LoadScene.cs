using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public PauseMenu pauseMenu;
    public GameObject tutorialPage;

    private void Start()
    {
        if (pauseMenu != null)
        {
            pauseMenu.Resume();
        }
    }

    public void ShowTutorial()
    {
        if (tutorialPage != null)
        {
            tutorialPage.SetActive(true); 
        }
    }

    public void LoadSceneMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadSceneGame()
    {
        SceneManager.LoadScene("Game"); 
    }

    public void LoadSceneCredit()
    {
        SceneManager.LoadScene("CreditScene");
    }
}
