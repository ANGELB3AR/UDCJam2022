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
    [field: SerializeField] public LevelManager LevelManager { get; private set; }
    [field: SerializeField] public MenuManager MenuManager { get; private set; }
    [field: SerializeField] public Health Player { get; private set; } = null;
    [field: SerializeField] public HUD HUD { get; private set; } = null;

    void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        LevelManager.OnNewLevel += OnLevelChange;
    }

    private void OnDisable()
    {
        LevelManager.OnNewLevel -= OnLevelChange;
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
            case GameState.Loading:
                HandleLoadingLevel();
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

    void HandleLoadingLevel()
    {
        Debug.Log("Game Loading");

        LevelManager.OnLevelLoaded += OnLevelFinishedLoading;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1;
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

        FindTemporaryObjects();

        InputReader.PauseEvent += OnPause;
        Player.OnDeath += OnPlayerDeath;
        HUD.OnPlayerWin += OnPlayerWin;
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

        LevelManager.LoadMainMenu();

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        Time.timeScale = 1;
    }

    void OnUnpause()
    {
        UpdateGameState(GameState.Playing);
        InputReader.PauseEvent -= OnUnpause;
    }

    void OnPause()
    {
        UpdateGameState(GameState.Paused);
        InputReader.PauseEvent -= OnPause;
    }

    void OnPlayerWin()
    {
        UpdateGameState(GameState.Win);
        HUD.OnPlayerWin -= OnPlayerWin;
    }

    void OnPlayerDeath()
    {
        UpdateGameState(GameState.Lose);
        Player.OnDeath -= OnPlayerDeath;
    }

    void OnLevelChange()
    {
        UpdateGameState(GameState.Loading);
    }

    void OnLevelFinishedLoading()
    {
        UpdateGameState(GameState.Playing);
        LevelManager.OnLevelLoaded -= OnLevelFinishedLoading;
    }

    void FindTemporaryObjects()
    {
        Player = FindObjectOfType<PlayerStateMachine>().GetComponent<Health>();
        HUD = FindObjectOfType<HUD>();
    }

    public enum GameState
    {
        Menu,
        Loading,
        Playing,
        Paused,
        Lose,
        Win
    }
}
