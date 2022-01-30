using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using DG.Tweening;

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
    private float rotationSpeed = 90f;


    public override void Begin()
    {
        laser.SetActive(true);
        laser.transform.position = GameManager.Instance.Character.transform.position;
        teamedObject = laser.GetComponent<TeamedObject>();
        remainingTickRate = tickRate;
        laser.transform.DOScale(scale, 0.15f);
    }

    public override void Stop()
    {
        laser.transform.DOScale(0, 0.15f).OnComplete(() => laser.SetActive(false));
    }

    public override void Update()
    {
        MoveTowardsPlayer();
        RotateLaser();
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

    private void RotateLaser()
    {
        laser.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    private void CheckCloseEnnemies()
    {
        List<Collider2D> ennemies = Physics2D.OverlapCircleAll(laser.transform.position, maxHitDistance).Where(t => t.GetComponent<Enemy>()).ToList();
        for (int i = 0; i < ennemies.Count; i++)
        {
            float distance = Vector2.Distance(ennemies[i].transform.position, laser.transform.position);
            if (distance > minHitDistance)
            {
                ennemies[i].GetComponent<Enemy>().Collide(teamedObject);
            }
        }
    }
}
