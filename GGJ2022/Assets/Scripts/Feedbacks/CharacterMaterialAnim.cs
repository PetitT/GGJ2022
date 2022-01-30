using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CharacterMaterialAnim : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Color defaultColor;
    private float intensityMultiplier = 200;

    private void Start()
    {
        GameManager.Instance.HealthManager.onHealthChanged += HealthManager_onHealthChanged;
        sprite = GameManager.Instance.Character.GetComponent<SpriteRenderer>();
        defaultColor = sprite.material.color;
    }

    private void OnDestroy()
    {
        GameManager.Instance.HealthManager.onHealthChanged -= HealthManager_onHealthChanged;
    }

    private void HealthManager_onHealthChanged(int obj)
    {
       // AnimateMaterial();
    }

    private async void AnimateMaterial()
    {
        float currentIntensity = 0;
        while (currentIntensity < 10)
        {
            currentIntensity += Time.deltaTime * intensityMultiplier;
            if (sprite != null)
            {
                Color newColor = defaultColor * currentIntensity;
                sprite.material.color = newColor;
                await Task.Yield();
            }
        }
        while (currentIntensity > 0)
        {
            currentIntensity -= Time.deltaTime * intensityMultiplier;
            if (sprite != null)
            {
                Color newColor = defaultColor * currentIntensity;
                sprite.material.color = newColor;
                await Task.Yield();
            }
        }
        sprite.material.color = defaultColor;
    }
}
