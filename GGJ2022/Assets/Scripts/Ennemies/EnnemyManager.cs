using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyManager : MonoBehaviour
{
    private Health health;
    private TeamedObject teamedObject;

    private void Awake()
    {
        health = new Health(GameManager.Instance.Data.EnnemyMaxHealth);
        teamedObject = GetComponent<TeamedObject>();
        health.onDeath += Health_onDeath;
    }


    private void OnEnable()
    {
        health.ResetHealth();
    }

    private void OnDestroy()
    {
        health.onDeath -= Health_onDeath;
    }

    private void Health_onDeath()
    {
        gameObject.SetActive(false);
    }

    public void Collide(TeamedObject obj)
    {
        if (obj.currentTeam != teamedObject.currentTeam)
        {
            health.TakeDamage(1);
        }
    }

}
