using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayingState : GameBaseState
{
    public GamePlayingState(GameStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.InputReader.PauseEvent += OnPause;
        stateMachine.Player.OnDeath += HandlePlayerDeath;
        stateMachine.HUD.OnPlayerWin += HandlePlayerWin;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1;

        stateMachine.FindTemporaryObjects();
    }

    public override void Tick(float deltaTime)
    {
        
    }

    public override void Exit()
    {
        stateMachine.InputReader.PauseEvent -= OnPause;
        stateMachine.Player.OnDeath -= HandlePlayerDeath;
        stateMachine.HUD.OnPlayerWin -= HandlePlayerWin;
    }

    void OnPause()
    {
        stateMachine.SwitchState(new GamePausedState(stateMachine));
    }

    void HandlePlayerDeath()
    {
        stateMachine.SwitchState(new GameOverState(stateMachine));
    }

    void HandlePlayerWin()
    {
        stateMachine.SwitchState(new GameNextLevelState(stateMachine));
    }

}
