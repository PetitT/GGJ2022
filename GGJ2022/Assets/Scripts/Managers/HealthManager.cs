using DG.Tweening;
using DG.Tweening.Core.Easing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        if (obj != 0 || obj != 3)
        {
            SoundManager.Instance.PlayClip(gameManager.feedbackData.playerDamage);
        }
    }

    private void Health_onDeath()
    {
        onDeath?.Invoke();
        SoundManager.Instance.PlayClip(gameManager.feedbackData.playerExplosion);
        DoBigExplosion();
    }

    private async void DoBigExplosion()
    {
        float random = 1;
        Vector2 currentPos = gameManager.Character.transform.position;
        for (int i = 0; i < 10; i++)
        {
            float X = UnityEngine.Random.Range(-random, random);
            float Y = UnityEngine.Random.Range(-random, random);
            Vector2 newPos = new Vector2(currentPos.x + X, currentPos.y + Y);
            Pool.Instance.GetItemFromPool(gameManager.feedbackData.redlongExplosion, newPos);
            SoundManager.Instance.PlayClip(gameManager.feedbackData.enemyExplosion);
            await Task.Delay(250);
        }
        gameManager.Fade.DOColor(new Color(gameManager.Fade.color.r, gameManager.Fade.color.g, gameManager.Fade.color.b, 1), 1f);
        await Task.Delay(2000);

        gameManager.Restart();
    }

    public void TakeDamage(int damage)
    {
        health.TakeDamage(damage);
    }
}
