using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingState : PlayerBaseState
{
    public PlayerJumpingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Rigidbody.AddForce(new Vector3(0, stateMachine.JumpForce, 0));
    }

    public override void Tick(float deltaTime)
    {
        Run(deltaTime);
    }

    public override void Exit()
    {
        
    }
}
