using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackingState : PlayerBaseState
{
    readonly int slashAttackHash = Animator.StringToHash("SlashAttack");

    const float crossFadeDuration = 0.1f;

    public PlayerAttackingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(slashAttackHash, crossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        Run(deltaTime);

        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "SlashAttack");

        if (normalizedTime >= 1f)
        {
            stateMachine.SwitchState(new PlayerRunningState(stateMachine));
        }

        Debug.Log("Player Attacking State");
    }

    public override void Exit()
    {
        
    }
}
