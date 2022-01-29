using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyCollision : MonoBehaviour
{
    public event Action<TeamedObject> onCollision;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out TeamedObject teamedObject))
        {
            onCollision?.Invoke(teamedObject);
        }
    }
}
