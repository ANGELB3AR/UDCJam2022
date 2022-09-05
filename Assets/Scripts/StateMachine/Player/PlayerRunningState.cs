using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunningState : PlayerBaseState
{
    readonly int sprintBlendTreeHash = Animator.StringToHash("SprintBlendTree");
    readonly int sprintDirectionHash = Animator.StringToHash("SprintXDirection");

    const float crossFadeDuration = 0.1f;

    public PlayerRunningState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.InputReader.JumpEvent += OnJump;
        stateMachine.InputReader.AttackEvent += OnAttack;

        stateMachine.Animator.CrossFadeInFixedTime(sprintBlendTreeHash, crossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        Run(deltaTime, stateMachine.RunningSpeed);

        stateMachine.Animator.SetFloat(sprintDirectionHash, stateMachine.InputReader.MovementValue.x);
    }

    public override void Exit()
    {
        stateMachine.InputReader.JumpEvent -= OnJump;
        stateMachine.InputReader.AttackEvent -= OnAttack;
    }

    void OnJump()
    {
        stateMachine.SwitchState(new PlayerJumpingState(stateMachine));
    }

    void OnAttack()
    {
        stateMachine.SwitchState(new PlayerAttackingState(stateMachine));
    }
}
