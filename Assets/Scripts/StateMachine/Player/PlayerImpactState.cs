using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImpactState : PlayerBaseState
{
    readonly int impactHash = Animator.StringToHash("Impact");

    const float crossFadeDuration = 0.1f;

    public PlayerImpactState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(impactHash, crossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        Run(deltaTime, stateMachine.StumblingSpeed);

        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "Impact");

        if (normalizedTime == 1f)
        {
            stateMachine.SwitchState(new PlayerRunningState(stateMachine));
        }
    }

    public override void Exit() { }
}
