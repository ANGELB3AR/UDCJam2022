using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public event Action OnLevelLoaded;

    public int currentLevel;
    public int mainMenu = 0;
    public int firstLevel = 2;

    int lastLevel;

    void Start()
    {
        lastLevel = SceneManager.sceneCountInBuildSettings;
    }

    void Update()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnDisable()
    {
        Debug.Log("DISABLED");
    }
    private void OnDestroy()
    {
        Debug.Log("DESTROYED");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
        GameManager.Instance.UpdateGameState(GameManager.GameState.Menu);
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

    IEnumerator LoadLevel(int level)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(level);
        asyncLoad.allowSceneActivation = false;

        while (asyncLoad.progress < 0.9f)
        {
            Debug.Log(asyncLoad.progress);
            yield return null;
            Debug.Log("STUCK HERE");
        }

        Debug.Log("Loading complete");
        asyncLoad.allowSceneActivation = true;
        OnLevelLoaded?.Invoke();
    }
}
