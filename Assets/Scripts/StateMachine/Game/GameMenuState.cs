using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuState : GameBaseState
{
    public GameMenuState(GameStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.LevelManager.LoadMainMenu();

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        Time.timeScale = 1;

        Debug.Log("Game Menu");
    }

    public override void Tick(float deltaTime)
    {

    }

    public override void Exit()
    {

    }
}
