using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : StateMachine
{
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public CentralizedGravity Gravity { get; private set; }
    [field: SerializeField] public Health Health { get; private set; }
    [field: SerializeField] public Collider weaponCollider { get; private set; }
    [field: SerializeField] public float AttackRange { get; private set; }
    [field: SerializeField] public float ChaseSpeed { get; private set; }
    [field: SerializeField] public float LocomotionSpeed { get; private set; }
    [field: SerializeField] public string AttackAnimation { get; private set; }
    [HideInInspector] public Health Player { get; private set; }
    [HideInInspector] public HUD HUD { get; private set; }

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        HUD = FindObjectOfType<HUD>();
    }

    void OnEnable()
    {
        Health.OnDeath += HandleDeath;
        Player.OnDeath += HandlePlayerDeath;
    }

    private void Start()
    {
        SwitchState(new EnemyChasingState(this));
    }

    void OnDisable()
    {
        Health.OnDeath -= HandleDeath;
        Player.OnDeath += HandlePlayerDeath;
    }

    void OnTriggerEnter(Collider other)
    {
        if (Health.GetCurrentHealth() == 0) { return; }

        if (other.CompareTag("Weapon"))
        {
            SwitchState(new EnemyImpactState(this));
            Health.ReceiveDamage(other.GetComponent<DamageDealer>().damageAmount);
        }
    }

    void HandleDeath()
    {
        SwitchState(new EnemyDyingState(this));
    }

    void HandlePlayerDeath()
    {
        if (Health.GetCurrentHealth() == 0) { return; }

        SwitchState(new EnemyIdleState(this));
    }
}
