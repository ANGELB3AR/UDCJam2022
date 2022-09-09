using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    int mainMenu = 1;
    int lastLevel = SceneManager.sceneCountInBuildSettings;

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void LoadNextLevel()
    {
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextLevel > lastLevel)
        {
            LoadMainMenu();
            return;
        }

        SceneManager.LoadScene(nextLevel);
    }
}
