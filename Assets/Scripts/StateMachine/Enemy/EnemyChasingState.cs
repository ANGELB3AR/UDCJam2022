using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasingState : EnemyBaseState
{
    public EnemyChasingState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        
    }

    public override void Tick(float deltaTime)
    {
        ChasePlayer();
        FacePlayer();

        if (IsInAttackRange())
        {
            stateMachine.SwitchState(new EnemyAttackingState(stateMachine));
        }
    }

    public override void Exit()
    {
        
    }

    bool IsInAttackRange()
    {
        float distanceToPlayer = Vector3.Distance(stateMachine.Player.transform.position, stateMachine.transform.position);
        return distanceToPlayer <= stateMachine.AttackRange;
    }

    void ChasePlayer()
    {
        Vector3 playerPosition = stateMachine.Player.transform.position;
        stateMachine.transform.position = Vector3.MoveTowards(stateMachine.transform.position, playerPosition, stateMachine.ChaseSpeed);
    }
}
