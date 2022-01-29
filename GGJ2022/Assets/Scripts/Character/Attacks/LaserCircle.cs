using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCircle : BaseAttack
{
    private GameObject laser => GameManager.Instance.Laser;
    private float scale => GameManager.Instance.Data.LaserScale;
    private float followSpeed => GameManager.Instance.Data.LaserSpeed;

    public override void Begin()
    {
        laser.SetActive(true);
        laser.transform.position = GameManager.Instance.Character.transform.position;
    }

    public override void Stop()
    {
        laser.SetActive(false);
    }

    public override void Update()
    {
        MoveTowardsPlayer();
        UpdateScale();
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
}
