using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject nextLevelMenu;
    [SerializeField] GameObject pauseMenu;

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

    void OnEnable()
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    void OnDisable()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    void GameManagerOnGameStateChanged(GameManager.GameState state)
    {
        gameOverMenu.SetActive(state == GameManager.GameState.Lose);
        nextLevelMenu.SetActive(state == GameManager.GameState.Win);
        pauseMenu.SetActive(state == GameManager.GameState.Paused);
    }
}
