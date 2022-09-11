using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDyingState : EnemyBaseState
{
    readonly int deathHash = Animator.StringToHash("Death");

    const float crossFadeDuration = 0.1f;

    public EnemyDyingState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(deathHash, crossFadeDuration);

        FMODUnity.RuntimeManager.PlayOneShot("event:/BodyDrop", stateMachine.transform.position);

        stateMachine.WeaponCollider.enabled = false;

        stateMachine.HUD.Recount();
        stateMachine.DisableEnemy();
    }

    public override void Tick(float deltaTime) 
    {
        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "Death");

        if (normalizedTime >= 1f)
        {
            stateMachine.DisableEnemy();
        }
    }

    public override void Exit() { }
}
