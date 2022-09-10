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
        SceneManager.LoadSceneAsync(mainMenu);
    }

    public void StartGame()
    {
        StartCoroutine(LoadLevel(firstLevel));
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

    //async void LoadLevel(int level)
    //{
    //    OnNewLevel?.Invoke();

    //    var scene = SceneManager.LoadSceneAsync(level);
    //    scene.allowSceneActivation = false;

    //    await System.Threading.Tasks.Task.CompletedTask;

    //    scene.allowSceneActivation = true;
    //    OnLevelLoaded?.Invoke();
    //}

    IEnumerator LoadLevel(int level)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(level);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        OnLevelLoaded?.Invoke();
    }
}
