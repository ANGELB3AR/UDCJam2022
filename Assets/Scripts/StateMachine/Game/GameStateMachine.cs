using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : StateMachine
{
    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public LevelManager LevelManager { get; private set; }
    [field: SerializeField] public GameObject PauseMenu { get; private set; }
    [field: SerializeField] public GameObject GameOverMenu { get; private set; }

    [HideInInspector] public Health Player { get; private set; }

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    void OnEnable()
    {
        Player.OnDeath += HandlePlayerDeath;
    }

    void Start()
    {
        PauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
        GameOverMenu = GameObject.FindGameObjectWithTag("GameOverMenu");

        PauseMenu.SetActive(false);
        GameOverMenu.SetActive(false);

        SwitchState(new GamePlayingState(this));
    }

    void OnDisable()
    {
        Player.OnDeath -= HandlePlayerDeath;
    }

    void HandlePlayerDeath()
    {
        SwitchState(new GameOverState(this));
    }

    public void ResumeGame()
    {
        SwitchState(new GamePlayingState(this));
    }

    public void LoadMainMenu()
    {
        SwitchState(new GameMenuState(this));
    }

    public void PlayGame()
    {
        LevelManager.LoadLevel(1);
        SwitchState(new GamePlayingState(this));
    }
}
