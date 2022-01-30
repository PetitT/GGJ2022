using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollisionManager : BaseManager
{
    private float InvulnerabilityTime => gameData.InvulnerabilityTime;
    private float remainingInvulnerabilityTime;

    private bool IsInvulnerable;

    public override void OnAwake()
    {
        CharacterCollision.Instance.onCollide += Instance_onCollide;
    }

    public override void OnUpdate()
    {
        Timer.CountDown(ref remainingInvulnerabilityTime, () => IsInvulnerable = false);
    }

    private void Instance_onCollide(Team collidedObjectTeam)
    {
        if (IsInvulnerable) return;

        Team currentTeam = gameManager.TeamManager.currentTeam;
        if(collidedObjectTeam != currentTeam)
        {
            gameManager.HealthManager.TakeDamage(1);
            IsInvulnerable = true;
            remainingInvulnerabilityTime = InvulnerabilityTime;
        }
    }
}
