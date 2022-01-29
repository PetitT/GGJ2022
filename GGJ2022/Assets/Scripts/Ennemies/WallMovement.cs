using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    private AnimationCurve speedCurve => GameManager.Instance.Data.WallSpeedCurve;
    private float maximumSpeed => GameManager.Instance.Data.WallSpeed;
    private float lifeTime;
    private float maxlifeTime = 5;

    private void OnEnable()
    {
        lifeTime = 0;
    }

    private void Update()
    {
        Handlelifetime();
        Move();
    }

    private void Handlelifetime()
    {
        lifeTime += Time.deltaTime;
        if(lifeTime > maxlifeTime)
        {
            gameObject.SetActive(false);
        }
    }

    private void Move()
    {
        float currentSpeed = speedCurve.Evaluate(lifeTime);
        transform.Translate(currentSpeed * Time.deltaTime * Vector2.up);
    }
}
