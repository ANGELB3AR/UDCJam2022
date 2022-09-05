using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState : State
{
    protected EnemyStateMachine stateMachine;

    public EnemyBaseState(EnemyStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public void FacePlayer()
    {
        if (stateMachine.Player == null) { return; }

        Vector3 lookDirection = stateMachine.Player.transform.position - stateMachine.transform.position;
        lookDirection.y = 0f;

        stateMachine.transform.rotation = Quaternion.LookRotation(lookDirection, stateMachine.transform.up);
    }
}
