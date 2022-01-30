using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : BaseAttack
{
    private GameObject missile => GameManager.Instance.Data.Missile;
    private float TimeBetweenLaunches => GameManager.Instance.Data.MissileFireRate;
    private float RemainingTimeToLaunch;

    public override void Update()
    {
        Timer.LoopedCountDown(ref RemainingTimeToLaunch, TimeBetweenLaunches, Shoot);
    }

    private void Shoot()
    {
        Vector2 position = GameManager.Instance.Character.transform.position;
        GenerateNewMissile(position, Vector2.up);
        GenerateNewMissile(position, Vector2.right);
        GenerateNewMissile(position, Vector2.down);
        GenerateNewMissile(position, Vector2.left);
        GenerateNewMissile(position, new Vector2(1, 1));
        GenerateNewMissile(position, new Vector2(-1, -1));
        GenerateNewMissile(position, new Vector2(-1, 1));
        GenerateNewMissile(position, new Vector2(1, -1));

        SoundManager.Instance.PlayClip(GameManager.Instance.feedbackData.missileShot);
    }

    private void GenerateNewMissile(Vector2 position, Vector2 direction)
    {
        GameObject newMissile = Pool.Instance.GetItemFromPool(missile, position);
        newMissile.transform.up = direction;
    }
}
