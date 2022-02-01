using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDisplay : MonoBehaviour
{
    public Sprite BlueShip;
    public Sprite RedShip;

    public Image shipImage;
    public Image backgroundImage;

    public Color BlueColor;
    public Color RedColor;

    private void Start()
    {
        GameManager.Instance.TeamManager.onTeamChanged += TeamManager_onTeamChanged;
        UpdateShipColor(GameManager.Instance.TeamManager.currentTeam);
    }

    private void TeamManager_onTeamChanged(Team obj)
    {
        UpdateShipColor(obj);
    }

    private void UpdateShipColor(Team newTeam)
    {
        shipImage.sprite = newTeam == Team.Red ? BlueShip : RedShip;
        backgroundImage.color = newTeam == Team.Red ? BlueColor : RedColor;
    }
}
