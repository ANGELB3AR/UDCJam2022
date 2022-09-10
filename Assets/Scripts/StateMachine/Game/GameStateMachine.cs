using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : StateMachine
{
    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public LevelManager LevelManager { get; private set; }
    [field: SerializeField] public GameObject PauseMenu { get; private set; }
    [field: SerializeField] public GameObject GameOverMenu { get; private set; }
    [field: SerializeField] public GameObject NextLevelMenu { get; private set; }

    [field: SerializeField] public HUD HUD { get; private set; }

    [HideInInspector] public Health Player { get; private set; }

    private void Awake()
    {
        PauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
        GameOverMenu = GameObject.FindGameObjectWithTag("GameOverMenu");
        NextLevelMenu = GameObject.FindGameObjectWithTag("NextLevelMenu");
    }

    void Start()
    {
        PauseMenu.SetActive(false);
        GameOverMenu.SetActive(false);
        NextLevelMenu.SetActive(false);

        SwitchState(new GameMenuState(this));
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
        SwitchState(new GameStartState(this));
    }

    public void FindTemporaryObjects()
    {
        HUD = FindObjectOfType<HUD>();
        Player = FindObjectOfType<PlayerStateMachine>().GetComponent<Health>();
    }
}
