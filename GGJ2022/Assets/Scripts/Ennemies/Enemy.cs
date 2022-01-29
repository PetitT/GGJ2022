using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event Action onDeath;

    private Health health;
    private TeamedObject teamedObject;
    public BaseAI AI;

    private void Awake()
    {
        health = new Health(GameManager.Instance.Data.EnnemyMaxHealth);
        teamedObject = GetComponent<TeamedObject>();
        health.onDeath += Health_onDeath;

        AI = Instantiate(AI);
    }

    void Update()
    {
        AI.Execute();
    }

    private void OnEnable()
    {
        health.ResetHealth();

        AI.Initialize(transform, GameManager.Instance.Character.transform);
    }

    private void OnDestroy()
    {
        health.onDeath -= Health_onDeath;
    }

    private void Health_onDeath()
    {
        gameObject.SetActive(false);
        onDeath?.Invoke();
    }

    public void Collide(TeamedObject obj)
    {
        if (obj.currentTeam != teamedObject.currentTeam)
        {
            health.TakeDamage(1);
        }
    }

}
