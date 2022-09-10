using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public event Action OnNewLevel;
    public event Action OnLevelLoaded;

    public int currentLevel;
    public int firstLevel = 2;

    int mainMenu = 1;
    int lastLevel;

    void Start()
    {
        lastLevel = SceneManager.sceneCountInBuildSettings;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync(mainMenu);
        currentLevel = mainMenu;
    }

    public void StartGame()
    {
        LoadLevel(firstLevel);
        currentLevel = firstLevel;
    }

    public void ReloadLevel()
    {
        LoadLevel(currentLevel);
    }

    public void LoadNextLevel()
    {
        int nextLevel = currentLevel + 1;

        if (nextLevel > lastLevel)
        {
            LoadMainMenu();
            return;
        }

        LoadLevel(nextLevel);
    }

    async void LoadLevel(int level)
    {
        OnNewLevel?.Invoke();

        var scene = SceneManager.LoadSceneAsync(level);
        scene.allowSceneActivation = false;

        do
        {
            await System.Threading.Tasks.Task.Delay(100);
        }
        while (scene.progress < 0.9f);

        scene.allowSceneActivation = true;
        currentLevel = level;
        OnLevelLoaded?.Invoke();
    }
}
