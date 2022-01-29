using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleAnimation : MonoBehaviour
{
    private Vector2 scaleRange = new Vector2(0.85f, 1.15f);
    private float defaultScale;
    private float lifeTime;

    private void Awake()
    {
        defaultScale = transform.localScale.x;
    }

    private void Update()
    {
        lifeTime += Time.deltaTime;

        float current = Mathf.Cos(lifeTime);

        float currentValue = MathExtensions.MapRange(current, 0, 1, 0.9f, 1.1f) * defaultScale;
        transform.localScale = new Vector2(currentValue, currentValue);

    }
}
