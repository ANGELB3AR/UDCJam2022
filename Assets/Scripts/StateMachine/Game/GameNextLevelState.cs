using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameNextLevelState : GameBaseState
{
    public GameNextLevelState(GameStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        Time.timeScale = 0;

        stateMachine.NextLevelMenu.SetActive(true);

        Debug.Log("Game Next Level");
    }

    public override void Tick(float deltaTime)
    {

    }

    public override void Exit()
    {
        stateMachine.NextLevelMenu.SetActive(false);
    }

}
