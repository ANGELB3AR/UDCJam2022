using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunningState : PlayerBaseState
{
    public PlayerRunningState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.InputReader.JumpEvent += OnJump;
    }

    public override void Tick(float deltaTime)
    {
        Run(deltaTime);
    }

    public override void Exit()
    {
        stateMachine.InputReader.JumpEvent -= OnJump;
    }

    void OnJump()
    {
        stateMachine.SwitchState(new PlayerJumpingState(stateMachine));
    }
}
