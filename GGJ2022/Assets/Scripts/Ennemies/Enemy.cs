using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event Action onDeath;

    public int maxHealth = 5;

    private Health health;
    private TeamedObject teamedObject;
    private SpriteRenderer sprite;
    public BaseAI AI;
    private Color defaultColor;

    private void Awake()
    {
        health = new Health(maxHealth);
        teamedObject = GetComponent<TeamedObject>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        defaultColor = sprite.color;
        health.onDeath += Health_onDeath;

        AI = Instantiate(AI);
    }

    void Update()
    {
        AI.Execute();

        if (!GameManager.Instance.CameraBordermanager.IsWithinScreenBounds(transform.position, 5.0f))
            gameObject.SetActive(false);
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
        SpawnBigExplosion();
    }

    public void Collide(TeamedObject obj)
    {
        if (obj.currentTeam != teamedObject.currentTeam)
        {
            health.TakeDamage(1);
            if (health.CurrentHealth > 0)
            {
                SoundManager.Instance.PlayClip(GameManager.Instance.feedbackData.enemyExplosion);
                SpawnExplosion();

                Sequence s = DOTween.Sequence();

                s.Append(sprite.material.DOColor(defaultColor * 10, 0.05f));
                s.Append(sprite.material.DOColor(defaultColor, 0.05f));
                s.Play();
            }
        }
    }

    private void SpawnExplosion()
    {
        Vector2 explosionPosition = transform.position /*+ (GameManager.Instance.Character.transform.position - transform.position).normalized*/;
        GameObject Explosion = Pool.Instance.GetItemFromPool(GameManager.Instance.feedbackData.explosion, explosionPosition);
        Vector2 direction = (GameManager.Instance.Character.transform.position - transform.position).normalized;
        Explosion.transform.up = direction;
    }

    private void SpawnBigExplosion()
    {
        GameObject newExplosion = Pool.Instance.GetItemFromPool(GameManager.Instance.feedbackData.longExplosion, transform.position);
        newExplosion.transform.Rotate(Vector3.forward * UnityEngine.Random.Range(0, 360));
    }
}
