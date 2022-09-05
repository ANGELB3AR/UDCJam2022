using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackingState : PlayerBaseState
{
    readonly int spinAttackHash = Animator.StringToHash("SpinAttack");

    const float crossFadeDuration = 0.1f;

    public PlayerAttackingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(spinAttackHash, crossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        Run(deltaTime);

        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "SpinAttack");

        if (normalizedTime >= 1f)
        {
            stateMachine.SwitchState(new PlayerRunningState(stateMachine));
        }
    }

    public override void Exit()
    {
        
    }
}
