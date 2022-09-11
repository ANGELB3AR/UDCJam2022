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
    public int lastLevel = 6;

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        int instanceCount = FindObjectsOfType(GetType()).Length;

        if (instanceCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
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
        GameManager.Instance.UpdateGameState(GameManager.GameState.Menu);
    }

    public void StartGame()
    {
        StartCoroutine(LoadLevel(firstLevel));
    }

    public void ReloadLevel()
    {
        StartCoroutine(LoadLevel(currentLevel));
    }

    public void LoadNextLevel()
    {
        int nextLevel = currentLevel + 1;

        if (nextLevel > lastLevel)
        {
            LoadMainMenu();
            return;
        }

        StartCoroutine(LoadLevel(nextLevel));
    }

    IEnumerator LoadLevel(int level)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(level);
        asyncLoad.allowSceneActivation = false;

        while (asyncLoad.progress < 0.9f)
        {
            yield return null;
        }

        Debug.Log("Loading complete");
        asyncLoad.allowSceneActivation = true;
        OnLevelLoaded?.Invoke();
    }
}
