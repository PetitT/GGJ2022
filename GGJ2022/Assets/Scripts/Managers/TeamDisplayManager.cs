using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamDisplayManager : BaseManager
{
    private SpriteRenderer sprite;

    public override void OnAwake()
    {
        gameManager.TeamManager.onTeamChanged += TeamManager_onTeamChanged;
        sprite = gameManager.Character.GetComponent<SpriteRenderer>();
    }

    private void TeamManager_onTeamChanged(Team obj)
    {
        switch (obj)
        {
            case Team.Red:
                sprite.color = Color.red;
                break;
            case Team.Blue:
                sprite.color = Color.blue;
                break;
            default:
                break;
        }
    }
}
