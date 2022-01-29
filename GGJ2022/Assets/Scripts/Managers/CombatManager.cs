using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : BaseManager
{
    private Dictionary<Team, BaseAttack> attacks = new Dictionary<Team, BaseAttack>();

    private BaseAttack currentAttack;

    public override void OnAwake()
    {
        gameManager.TeamManager.onTeamChanged += TeamManager_onTeamChanged;

        attacks.Add(Team.Red, new MissileLauncher());
        attacks.Add(Team.Blue, new LaserCircle());
    }

    private void TeamManager_onTeamChanged(Team newTeam)
    {
        currentAttack?.Stop();
        currentAttack = attacks[newTeam];
        currentAttack.Begin();
    }

    public override void OnUpdate()
    {
        currentAttack.Update();
    }
}
