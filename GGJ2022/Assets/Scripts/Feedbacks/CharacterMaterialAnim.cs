using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMaterialAnim : MonoBehaviour
{
    private SpriteRenderer sprite;

    private void Start()
    {
        GameManager.Instance.HealthManager.onHealthChanged += HealthManager_onHealthChanged;
        sprite = GameManager.Instance.Character.GetComponent<SpriteRenderer>();
    }

    private void OnDestroy()
    {
        GameManager.Instance.HealthManager.onHealthChanged -= HealthManager_onHealthChanged;
    }

    private void HealthManager_onHealthChanged(int obj)
    {
        sprite.material.color = sprite.material.color * 100;
    }
}
