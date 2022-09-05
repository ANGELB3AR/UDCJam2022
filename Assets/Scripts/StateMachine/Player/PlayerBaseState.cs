using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine stateMachine;

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public void Run(float deltaTime, float speed)
    {
        Vector3 movement = new Vector3();

        movement.x = 0f; ;
        movement.y = 0f;
        movement.z = speed;

        stateMachine.transform.Translate(movement * deltaTime * speed);

        Vector3 rotation = new Vector3();

        rotation.x = 0f;
        rotation.y = stateMachine.InputReader.MovementValue.x;
        rotation.z = 0f;

        stateMachine.transform.Rotate(rotation * deltaTime * stateMachine.TurnSpeed);
    }
}
