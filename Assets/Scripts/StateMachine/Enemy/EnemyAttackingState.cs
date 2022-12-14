using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackingState : EnemyBaseState
{
    const float crossFadeDuration = 0.1f;
    public EnemyAttackingState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(stateMachine.AttackAnimation, crossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        FacePlayer();

        if (GetNormalizedTime(stateMachine.Animator, stateMachine.AttackAnimation) >= 1)
        {
            if (stateMachine.Player.GetCurrentHealth() > 0)
            {
                stateMachine.SwitchState(new EnemyChasingState(stateMachine));
            }
            else
            {
                stateMachine.SwitchState(new EnemyIdleState(stateMachine));
            }
        }
    }

    public override void Exit() { }
}
