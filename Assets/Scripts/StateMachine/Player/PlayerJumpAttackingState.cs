using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpAttackingState : PlayerBaseState
{
    readonly int jumpAttackHash = Animator.StringToHash("JumpAttack");

    const float crossFadeDuration = 0.1f;

    public PlayerJumpAttackingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(jumpAttackHash, crossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        Run(deltaTime, stateMachine.RunningSpeed);

        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "JumpAttack");

        if (normalizedTime >= 1f)
        {
            stateMachine.SwitchState(new PlayerRunningState(stateMachine));
        }
    }

    public override void Exit() { }
}
