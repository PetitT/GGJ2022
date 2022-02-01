using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : BaseManager
{
    public Team currentTeam { get; private set; }
    public event Action<Team> onTeamChanged;
    private bool canChangeTeam = true;

    public void ToggleCanChangeTeam(bool toggle)
    {
        canChangeTeam = toggle;
    }

    public override void OnAwake()
    {
        gameManager.InputManager.onSpaceInput += InputManager_onSpaceInput;
        gameManager.TouchInputManager.onButtonClick += InputManager_onSpaceInput;
    }
    public override void OnBegin()
    {
        SwapTeam(Team.Blue);
    }

    private void InputManager_onSpaceInput()
    {
        if (!canChangeTeam) return;

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
