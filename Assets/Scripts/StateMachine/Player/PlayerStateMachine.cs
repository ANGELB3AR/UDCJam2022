using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public Rigidbody Rigidbody { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public Health Health { get; private set; }

    [field: SerializeField] public float RunningSpeed { get; private set; }
    [field: SerializeField] public float AttackingSpeed { get; private set; }
    [field: SerializeField] public float StumblingSpeed { get; private set; }
    [field: SerializeField] public float JumpForce { get; private set; }
    [field: SerializeField] public float TurnSpeed { get; private set; }
    [HideInInspector] public bool IsGrounded { get; private set; }
    [HideInInspector] public bool IsDead { get; private set; } = false;

    void OnEnable()
    {
        Health.OnDeath += HandleDeath;
    }

    void Start()
    {
        SwitchState(new PlayerRunningState(this));
    }

    void OnDisable()
    {
        Health.OnDeath -= HandleDeath;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (IsDead) { return; }

        if (other.CompareTag("Obstacle"))
        {
            SwitchState(new PlayerTrippingState(this));
        }
        else if (other.CompareTag("Weapon"))
        {
            SwitchState(new PlayerImpactState(this));
            Health.ReceiveDamage(other.GetComponent<DamageDealer>().damageAmount);
        }
    }

    public void SetIsGrounded(bool status)
    {
        IsGrounded = status;
    }

    void HandleDeath()
    {
        IsDead = true;
        SwitchState(new PlayerDyingState(this));
    }
}
