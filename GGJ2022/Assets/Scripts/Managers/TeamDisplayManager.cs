using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamDisplayManager : BaseManager
{

    public override void OnAwake()
    {
        gameManager.TeamManager.onTeamChanged += TeamManager_onTeamChanged;
    }

    private void TeamManager_onTeamChanged(Team obj)
    {


    }
}
