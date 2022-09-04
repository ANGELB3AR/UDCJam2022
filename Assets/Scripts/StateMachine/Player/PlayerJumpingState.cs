using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingState : PlayerBaseState
{
    readonly int jumpHash = Animator.StringToHash("Jump");

    const float crossFadeDuration = 0.1f;

    public PlayerJumpingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.InputReader.AttackEvent += OnAttack;

        stateMachine.Rigidbody.AddRelativeForce(new Vector3(0, stateMachine.JumpForce, 0), ForceMode.Impulse);

        stateMachine.Animator.CrossFadeInFixedTime(jumpHash, crossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        if (stateMachine.IsGrounded)
        {
            stateMachine.SwitchState(new PlayerRunningState(stateMachine));
        }
    }

    public override void Exit()
    {

    }

    void OnAttack()
    {
        stateMachine.SwitchState(new PlayerJumpAttackingState(stateMachine));
    }
}
