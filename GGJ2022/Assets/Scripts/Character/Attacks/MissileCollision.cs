using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileCollision : MonoBehaviour
{
    private TeamedObject teamedObject;

    private void Awake()
    {
        teamedObject = GetComponent<TeamedObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out EnnemyManager ennemy))
        {
            ennemy.Collide(teamedObject);
            gameObject.SetActive(false);
        }
    }
}
