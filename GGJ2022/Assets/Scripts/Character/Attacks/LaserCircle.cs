using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class LaserCircle : BaseAttack
{
    private GameObject laser => GameManager.Instance.Laser;
    private TeamedObject teamedObject;
    private float scale => GameManager.Instance.Data.LaserScale;
    private float minHitDistance => GameManager.Instance.Data.LaserMinHitDistance;
    private float maxHitDistance => GameManager.Instance.Data.LaserMaxHitDistance;
    private float followSpeed => GameManager.Instance.Data.LaserSpeed;

    private float tickRate => GameManager.Instance.Data.LaserTickRate;
    private float remainingTickRate;

    private Collider2D col;

    public override void Begin()
    {
        laser.SetActive(true);
        laser.transform.position = GameManager.Instance.Character.transform.position;
        col = laser.GetComponent<Collider2D>();
        teamedObject = laser.GetComponent<TeamedObject>();
        remainingTickRate = tickRate;
        col.enabled = false;
    }

    public override void Stop()
    {
        laser.SetActive(false);
    }

    public override void Update()
    {
        MoveTowardsPlayer();
        UpdateScale();
        Timer.LoopedCountDown(ref remainingTickRate, tickRate, () =>
        {
            CheckCloseEnnemies();
        });


        Debug.DrawLine(laser.transform.position, laser.transform.position + Vector3.right * maxHitDistance, Color.yellow);
        Debug.DrawLine(laser.transform.position, laser.transform.position + Vector3.right * minHitDistance, Color.red);
    }

    private void MoveTowardsPlayer()
    {
        Vector2 target = GameManager.Instance.Character.transform.position;
        laser.transform.position = Vector2.MoveTowards(laser.transform.position, target, followSpeed * Time.deltaTime);
    }

    private void UpdateScale()
    {
        laser.transform.localScale = new Vector2(scale, scale);
    }

    private void CheckCloseEnnemies()
    {
        List<Collider2D> ennemies = Physics2D.OverlapCircleAll(laser.transform.position, maxHitDistance).Where(t => t.GetComponent<EnnemyManager>()).ToList();
        for (int i = 0; i < ennemies.Count; i++)
        {
            float distance = Vector2.Distance(ennemies[i].transform.position, laser.transform.position);
            if(distance > minHitDistance)
            {
                ennemies[i].GetComponent<EnnemyManager>().Collide(teamedObject);
            }
        }        
    }
    
}
