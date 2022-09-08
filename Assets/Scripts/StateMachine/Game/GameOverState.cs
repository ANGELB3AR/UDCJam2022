using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : GameBaseState
{
    public GameOverState(GameStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        Time.timeScale = 0;

        stateMachine.GameOverMenu.SetActive(true);
    }

    public override void Tick(float deltaTime)
    {

    }

    public override void Exit()
    {
        stateMachine.GameOverMenu.SetActive(false);
    }
}
