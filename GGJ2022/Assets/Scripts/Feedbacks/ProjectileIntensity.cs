using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileIntensity : MonoBehaviour
{
    private SpriteRenderer sprite;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = sprite.color * 1000;
    }
}
