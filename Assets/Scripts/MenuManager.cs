using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject nextLevelMenu;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject loadingScreen;

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
        loadingScreen.SetActive(state == GameManager.GameState.Loading);
    }
}
