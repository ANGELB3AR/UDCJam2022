using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRollingState : PlayerBaseState
{
    readonly int rollHash = Animator.StringToHash("Roll");

    const float crossFadeDuration = 0.1f;

    public PlayerRollingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(rollHash, crossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        Run(deltaTime, stateMachine.RunningSpeed);

        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "Roll");

        if (normalizedTime == 1f)
        {
            stateMachine.SwitchState(new PlayerRunningState(stateMachine));
        }
    }

    public override void Exit() { }
}
