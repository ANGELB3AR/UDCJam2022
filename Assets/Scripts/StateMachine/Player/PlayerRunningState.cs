using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunningState : PlayerBaseState
{
    public PlayerRunningState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        
    }

    public override void Tick(float deltaTime)
    {
        Vector3 movement = new Vector3();

        movement.x = stateMachine.InputReader.MovementValue.x;
        movement.y = 0f;
        movement.z = stateMachine.RunningSpeed;

        stateMachine.transform.Translate(movement * deltaTime * stateMachine.RunningSpeed);
    }

    public override void Exit()
    {
        
    }
}
