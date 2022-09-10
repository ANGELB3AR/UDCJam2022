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

    [SerializeField] Slider progressBar;

    public int currentLevel;
    public int firstLevel = 2;

    int mainMenu = 1;
    int lastLevel;
    float target;
    float loadTime = 3f;

    void Start()
    {
        lastLevel = SceneManager.sceneCountInBuildSettings;
    }

    void Update()
    {
        progressBar.value = Mathf.MoveTowards(progressBar.value, target, loadTime * Time.deltaTime); ;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
        currentLevel = mainMenu;
    }

    public void StartGame()
    {
        LoadLevel(firstLevel);
    }

    public void ReloadLevel()
    {
        LoadLevel(currentLevel);
    }

    public void LoadNextLevel()
    {
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;

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

        target = 0f;
        //progressBar.value = 0f;

        var scene = SceneManager.LoadSceneAsync(level);
        scene.allowSceneActivation = false;

        do
        {
            await System.Threading.Tasks.Task.Delay(100);

            target = scene.progress;
        }
        while (scene.progress < 0.9f);

        currentLevel = level;
        scene.allowSceneActivation = true;
        OnLevelLoaded?.Invoke();
    }
}
