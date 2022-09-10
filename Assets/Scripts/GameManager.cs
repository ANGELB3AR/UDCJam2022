using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;

    public static event Action<GameState> OnGameStateChanged;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateGameState(GameState.Menu);
    }

    void Update()
    {
        
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.Menu:
                LoadMenu();
                break;
            case GameState.Starting:
                break;
            case GameState.Playing:
                break;
            case GameState.Paused:
                break;
            case GameState.Lose:
                break;
            case GameState.Win:
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }

    void LoadMenu()
    {
        
    }

    public enum GameState
    {
        Menu,
        Starting,
        Playing,
        Paused,
        Lose,
        Win
    }
}
