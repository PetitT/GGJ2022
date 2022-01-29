using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class LaserCircle : BaseAttack
{
    private GameObject laser => GameManager.Instance.Laser;
    private float scale => GameManager.Instance.Data.LaserScale;
    private float followSpeed => GameManager.Instance.Data.LaserSpeed;

    private float tickRate => GameManager.Instance.Data.LaserTickRate;
    private float remainingTickRate;

    private float toggleTime => GameManager.Instance.Data.LaserToggleTime;
    private float remainingToggleTime;

    private Collider2D col;

    public override void Begin()
    {
        laser.SetActive(true);
        laser.transform.position = GameManager.Instance.Character.transform.position;
        col = laser.GetComponent<Collider2D>();
        remainingTickRate = tickRate;
        remainingToggleTime = 0;
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
            ToggleCollision(true);
            remainingToggleTime = toggleTime;
        });

        Timer.CountDown(ref remainingToggleTime, () => { ToggleCollision(false); });
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
        //Collider3D[] ennemies = Physics2D.OverlapCircleAll(laser.transform.position, scale);
    }

    private void ToggleCollision(bool toggle)
    {
        Debug.Log(toggle);
        col.enabled = toggle;
    }
}
