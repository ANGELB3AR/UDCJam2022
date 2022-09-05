using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public event Action OnDeath;

    [SerializeField] int maxHealth = 50;

    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public void ReceiveDamage(int damage)
    {
        if (currentHealth == 0) { return; }

        currentHealth = Mathf.Max(currentHealth - damage, 0);

        if (currentHealth == 0)
        {
            OnDeath?.Invoke();
        }
    }
}
