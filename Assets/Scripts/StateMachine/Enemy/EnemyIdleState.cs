using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    readonly int idleHash = Animator.StringToHash("Idle");

    const float crossFadeDuration = 0.1f;

    public EnemyIdleState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(idleHash, crossFadeDuration);
    }

    public override void Tick(float deltaTime) { }

    public override void Exit()
    {
        
    }
}
