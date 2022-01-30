using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamDisplayManager : BaseManager
{

    private bool wasInitialized = false;

    public override void OnAwake()
    {
        gameManager.TeamManager.onTeamChanged += TeamManager_onTeamChanged;
    }

    private void TeamManager_onTeamChanged(Team obj)
    {
        if (!wasInitialized)
        {
            wasInitialized = true;
            return;
        }

        switch (obj)
        {
            case Team.Red:
                Pool.Instance.GetItemFromPool(gameManager.feedbackData.redElectricity, gameManager.Character.transform.position);
                SoundManager.Instance.PlayClip(gameManager.feedbackData.switchToRed);
                break;
            case Team.Blue:
                Pool.Instance.GetItemFromPool(gameManager.feedbackData.blueElectricity, gameManager.Character.transform.position);
                SoundManager.Instance.PlayClip(gameManager.feedbackData.switchToBlue);
                break;
            default:
                break;
        }
    }
}
