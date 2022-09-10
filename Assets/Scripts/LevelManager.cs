using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public event Action OnLevelLoad;

    [SerializeField] Slider progressBar;

    public int currentLevel;
    public int firstLevel = 2;
    public bool gameLoaded = false;

    int mainMenu = 1;
    int lastLevel;

    void Start()
    {
        lastLevel = SceneManager.sceneCountInBuildSettings;
    }

    void Update()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void StartGame()
    {
        LoadLevel(firstLevel);
    }

    public void ReloadLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel);
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

    public async void LoadLevel(int level)
    {
        var scene = SceneManager.LoadSceneAsync(level);
        scene.allowSceneActivation = false;

        do
        {
            await System.Threading.Tasks.Task.Delay(100);

            progressBar.value = scene.progress;
        }
        while (scene.progress < 0.9f);

        scene.allowSceneActivation = true;
    }
}
