using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDyingState : PlayerBaseState
{
    public event Action OnPlayerDeath;

    readonly int deathHash = Animator.StringToHash("Death");

    const float crossFadeDuration = 0.1f;

    public PlayerDyingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(deathHash, crossFadeDuration);

        FMODUnity.RuntimeManager.PlayOneShot("event:/BodyDrop", stateMachine.transform.position);

        OnPlayerDeath?.Invoke();
    }

    public override void Tick(float deltaTime) { }

    public override void Exit() { }
}
