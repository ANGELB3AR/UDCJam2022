using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDyingState : PlayerBaseState
{
    readonly int deathHash = Animator.StringToHash("Death");

    const float crossFadeDuration = 0.1f;

    public PlayerDyingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(deathHash, crossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {

    }

    public override void Exit()
    {

    }
}
