using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public Rigidbody Rigidbody { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public Health Health { get; private set; }

    [field: SerializeField] public float RunningSpeed { get; private set; }
    [field: SerializeField] public float JumpForce { get; private set; }
    [field: SerializeField] public int WeaponDamage { get; private set; }
    [HideInInspector] public bool IsGrounded { get; private set; }

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
        if (other.CompareTag("Obstacle"))
        {
            SwitchState(new PlayerTrippingState(this));
        }
        else if (other.CompareTag("Weapon"))
        {
            SwitchState(new PlayerImpactState(this));
            Health.ReceiveDamage(other.GetComponentInParent<EnemyStateMachine>().WeaponDamage);
        }
    }

    public void SetIsGrounded(bool status)
    {
        IsGrounded = status;
    }

    void HandleDeath()
    {
        SwitchState(new PlayerDyingState(this));
    }
}
