using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollisionManager : BaseManager
{
    public override void OnAwake()
    {
        CharacterCollision.Instance.onCollide += Instance_onCollide;
    }

    private void Instance_onCollide(Team collidedObjectTeam)
    {
        Team currentTeam = gameManager.TeamManager.currentTeam;
        if(collidedObjectTeam != currentTeam)
        {
            gameManager.HealthManager.TakeDamage(1);
        }
    }
}
