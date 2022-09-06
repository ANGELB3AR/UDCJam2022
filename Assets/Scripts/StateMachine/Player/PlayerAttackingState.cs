using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackingState : PlayerBaseState
{
    readonly int attackHash = Animator.StringToHash("OtherAttack");

    const float crossFadeDuration = 0.1f;

    public PlayerAttackingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(attackHash, crossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        Run(deltaTime, stateMachine.AttackingSpeed);

        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "OtherAttack");

        if (normalizedTime >= 1f)
        {
            stateMachine.SwitchState(new PlayerRunningState(stateMachine));
        }
    }

    public override void Exit()
    {
        
    }
}
