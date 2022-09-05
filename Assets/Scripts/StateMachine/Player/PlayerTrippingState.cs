using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrippingState : PlayerBaseState
{
    readonly int tripHash = Animator.StringToHash("Trip");

    const float crossFadeDuration = 0.1f;

    public PlayerTrippingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(tripHash, crossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        Run(deltaTime);

        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "Trip");

        if (normalizedTime == 1f)
        {
            stateMachine.SwitchState(new PlayerRunningState(stateMachine));
        }
    }

    public override void Exit() { }
}
