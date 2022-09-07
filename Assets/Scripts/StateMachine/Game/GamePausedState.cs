using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePausedState : GameBaseState
{
    public GamePausedState(GameStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.InputReader.PauseEvent += OnPause;

        stateMachine.PauseMenu.SetActive(true);

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        Time.timeScale = 0;
    }

    public override void Tick(float deltaTime)
    {

    }

    public override void Exit()
    {
        stateMachine.InputReader.PauseEvent -= OnPause;

        stateMachine.PauseMenu.SetActive(false);
    }

    void OnPause()
    {
        stateMachine.SwitchState(new GamePlayingState(stateMachine));
    }
}