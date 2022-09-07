using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : StateMachine
{
    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public LevelManager LevelManager { get; private set; }

    [HideInInspector] public Health Player { get; private set; }

    void OnEnable()
    {
        Player.OnDeath += HandlePlayerDeath;
    }

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();

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
}
