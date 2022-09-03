using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingState : PlayerBaseState
{
    public PlayerJumpingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Rigidbody.AddRelativeForce(new Vector3(0, stateMachine.JumpForce, 0), ForceMode.Impulse);
    }

    public override void Tick(float deltaTime)
    {
        Run(deltaTime);

        if (stateMachine.IsGrounded)
        {
            stateMachine.SwitchState(new PlayerRunningState(stateMachine));
        }
    }

    public override void Exit()
    {

    }
}
