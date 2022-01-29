using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollision : Singleton<CharacterCollision>
{
    public event Action<Team> onCollide;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.TryGetComponent(out TeamedObject teamedObject))
        { 
            onCollide?.Invoke(teamedObject.currentTeam);
        }
    }
}
