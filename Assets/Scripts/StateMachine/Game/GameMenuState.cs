using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuState : GameBaseState
{
    public GameMenuState(GameStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        Debug.Log("Game Menu");

        stateMachine.LevelManager.LoadMainMenu();

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        Time.timeScale = 1;
    }

    public override void Tick(float deltaTime)
    {

    }

    public override void Exit()
    {

    }
}
