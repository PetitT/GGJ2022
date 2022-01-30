using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CharacterMaterialAnim : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Color defaultColor;
    public float maximumIntensity = 5;

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
        Sequence s = DOTween.Sequence();
        s.Append(sprite.material.DOColor(defaultColor * maximumIntensity, 0.05f));
        s.Append(sprite.material.DOColor(defaultColor, 0.05f));
        s.SetLoops(3);
        s.Play();
    }
}
