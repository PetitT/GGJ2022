using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    public event Action<int> onHealthChanged;
    public event Action onDeath;

    private int maximumHealth;

    private int currentHealth;
    public int CurrentHealth
    {
        get
        {
            return currentHealth;
        }
        private set
        {
            currentHealth = value;
            onHealthChanged?.Invoke(currentHealth);
        }
    }

    public Health(int maximumHealth)
    {
        this.maximumHealth = maximumHealth;
        ResetHealth();
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth = Mathf.Max(CurrentHealth - damage, 0);
        if(CurrentHealth == 0)
        {
            onDeath?.Invoke();
        }
    }

    public void ResetHealth()
    {
        CurrentHealth = maximumHealth;
    }
}
