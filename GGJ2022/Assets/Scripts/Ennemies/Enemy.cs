using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event Action onDeath;

    public int maxHealth = 5;

    private Health health;
    private TeamedObject teamedObject;
    public BaseAI AI;

    private void Awake()
    {
        health = new Health(maxHealth);
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
        SoundManager.Instance.PlayClip(GameManager.Instance.feedbackData.enemyDeath);
    }

    public void Collide(TeamedObject obj)
    {
        if (obj.currentTeam != teamedObject.currentTeam)
        {
            health.TakeDamage(1);
            if (health.CurrentHealth > 0)
            {
                SoundManager.Instance.PlayClip(GameManager.Instance.feedbackData.enemyExplosion);
                Vector2 explosionPosition = transform.position /*+ (GameManager.Instance.Character.transform.position - transform.position).normalized*/;
                GameObject Explosion = Pool.Instance.GetItemFromPool(GameManager.Instance.feedbackData.explosion, explosionPosition);
                Vector2 direction = (GameManager.Instance.Character.transform.position - transform.position).normalized;
                Explosion.transform.up = direction;
            }
        }
    }

}
