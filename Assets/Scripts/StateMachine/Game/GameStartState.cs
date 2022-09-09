using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartState : GameBaseState
{
    public GameStartState(GameStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.LevelManager.StartGame();

        Debug.Log("Game Start");
    }

    public override void Tick(float deltaTime)
    {
        stateMachine.SwitchState(new GamePlayingState(stateMachine));
    }

    public override void Exit()
    {
        
    }
}
