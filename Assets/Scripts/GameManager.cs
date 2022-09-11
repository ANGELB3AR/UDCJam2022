using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;

    public static event Action<GameState> OnGameStateChanged;

    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public LevelManager LevelManager { get; private set; } = null;
    [field: SerializeField] public MenuManager MenuManager { get; private set; } = null;

    void Awake()
    {
        Instance = this;
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
        LevelManager.OnLevelLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        LevelManager.OnLevelLoaded -= OnLevelFinishedLoading;
    }

    void Start()
    {
        UpdateGameState(GameState.Menu);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.Menu:
                HandleMainMenu();
                break;
            case GameState.Playing:
                HandleGamePlaying();
                break;
            case GameState.Paused:
                HandleGamePaused();
                break;
            case GameState.Lose:
                HandleLevelLost();
                break;
            case GameState.Win:
                HandleLevelWon();
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }

    void HandleLevelWon()
    {
        Debug.Log("Game Win");

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        Time.timeScale = 0;
    }

    void HandleGamePlaying()
    {
        Debug.Log("Game Playing");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1;

        InputReader.PauseEvent += OnPause;
    }

    void HandleGamePaused()
    {
        Debug.Log("Game Paused");

        InputReader.PauseEvent += OnUnpause;

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        Time.timeScale = 0;
    }

    void HandleLevelLost()
    {
        Debug.Log("Game Over");

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        Time.timeScale = 0;
    }

    void HandleMainMenu()
    {
        Debug.Log("Game Menu");

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        Time.timeScale = 1;
    }

    public void OnUnpause()
    {
        UpdateGameState(GameState.Playing);
        InputReader.PauseEvent -= OnUnpause;
    }

    void OnPause()
    {
        UpdateGameState(GameState.Paused);
        InputReader.PauseEvent -= OnPause;
    }

    void OnLevelFinishedLoading()
    {
        UpdateGameState(GameState.Playing);
    }

    public enum GameState
    {
        Menu,
        Playing,
        Paused,
        Lose,
        Win
    }
}
