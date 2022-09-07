using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayingState : GameBaseState
{
    public GamePlayingState(GameStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.InputReader.PauseEvent += OnPause;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1;
    }

    public override void Tick(float deltaTime)
    {
        
    }

    public override void Exit()
    {
        stateMachine.InputReader.PauseEvent -= OnPause;
    }

    void OnPause()
    {
        stateMachine.SwitchState(new GamePausedState(stateMachine));
    }
}
