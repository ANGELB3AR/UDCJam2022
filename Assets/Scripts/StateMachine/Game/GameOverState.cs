using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : GameBaseState
{
    public GameOverState(GameStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        Time.timeScale = 1;

        stateMachine.GameOverScreen.SetActive(true);
    }

    public override void Tick(float deltaTime)
    {

    }

    public override void Exit()
    {
        stateMachine.GameOverScreen.SetActive(false);
    }
}
