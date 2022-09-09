using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartState : GameBaseState
{
    public GameStartState(GameStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        Debug.Log("Game Start");

        stateMachine.LevelManager.StartGame();

        stateMachine.SwitchState(new GamePlayingState(stateMachine));
    }

    public override void Tick(float deltaTime)
    {
        if (stateMachine.LevelManager.currentLevel == stateMachine.LevelManager.firstLevel)
        {
            stateMachine.SwitchState(new GamePlayingState(stateMachine));
        }
    }

    public override void Exit()
    {
        
    }
}
