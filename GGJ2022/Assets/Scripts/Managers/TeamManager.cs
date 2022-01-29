using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : BaseManager
{
    public Team currentTeam { get; private set; }
    public event Action<Team> onTeamChanged;


    public override void OnAwake()
    {
        gameManager.InputManager.onSpaceInput += InputManager_onSpaceInput;
    }
    public override void OnBegin()
    {
        SwapTeam(Team.Red);
    }

    private void InputManager_onSpaceInput()
    {
        switch (currentTeam)
        {
            case Team.Red:
                SwapTeam(Team.Blue);
                break;
            case Team.Blue:
                SwapTeam(Team.Red);
                break;
            default:
                break;
        }
    }

    private void SwapTeam(Team newTeam)
    {
        currentTeam = newTeam;
        onTeamChanged?.Invoke(newTeam);
    }
}
