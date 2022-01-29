using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyManager : MonoBehaviour
{
    private Health health;
    private TeamedObject teamedObject;
    private EnnemyCollision collision;

    private void Awake()
    {
        health = new Health(GameManager.Instance.Data.EnnemyMaxHealth);
        teamedObject = GetComponent<TeamedObject>();
        collision = GetComponent<EnnemyCollision>();

        collision.onCollision += Collision_onCollision;
        health.onDeath += Health_onDeath;
    }


    private void OnEnable()
    {
        health.ResetHealth();
    }

    private void OnDestroy()
    {
        health.onDeath -= Health_onDeath;
        collision.onCollision -= Collision_onCollision;
    }

    private void Health_onDeath()
    {
        gameObject.SetActive(false);
    }

    private void Collision_onCollision(TeamedObject obj)
    {
        
    }

    public void Collide(TeamedObject obj)
    {
        
    }

    private void TakeDamage(int damage)
    {
        health.TakeDamage(damage);
    }
    
}
