using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : BaseManager
{
    public Health health { get; private set; }
    private int maximumHealth => gameData.CharacterMaxHealth;

    public event Action<int> onHealthChanged;
    public event Action onDeath;


    public override void OnAwake()
    {
        health = new Health(maximumHealth);
        health.onHealthChanged += Health_onHealthChanged;
        health.onDeath += Health_onDeath;
    }

    private void Health_onHealthChanged(int obj)
    {
        onHealthChanged?.Invoke(obj);
    }

    private void Health_onDeath()
    {
        onDeath?.Invoke();
    }
    public void TakeDamage(int damage)
    {
        health.TakeDamage(damage);
    }
}
