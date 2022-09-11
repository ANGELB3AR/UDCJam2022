using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public event Action OnDeath;

    public bool isInvincible = false;

    public int maxHealth = 50;

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
        if (isInvincible) { return; }

        currentHealth = Mathf.Max(currentHealth - damage, 0);
        Debug.Log($"{gameObject.name} received {damage} damage");

        if (currentHealth == 0)
        {
            print(gameObject.name + " has died");
            OnDeath?.Invoke();
        }
    }

    public void SetInvincible(bool status)
    {
        isInvincible = status;
    }
}
