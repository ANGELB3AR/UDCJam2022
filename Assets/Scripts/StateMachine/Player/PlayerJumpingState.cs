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
        stateMachine.SetIsGrounded(false);

        stateMachine.Animator.CrossFadeInFixedTime(jumpHash, crossFadeDuration);

        FMODUnity.RuntimeManager.PlayOneShot("event:/Jump", stateMachine.transform.position);
    }

    public override void Tick(float deltaTime)
    {
        Run(deltaTime, stateMachine.RunningSpeed);

        if (stateMachine.IsGrounded)
        {
            stateMachine.SwitchState(new PlayerRollingState(stateMachine));
        }
    }

    public override void Exit()
    {
        stateMachine.InputReader.AttackEvent -= OnAttack;
    }

    void OnAttack()
    {
        stateMachine.SwitchState(new PlayerJumpAttackingState(stateMachine));
    }
}
