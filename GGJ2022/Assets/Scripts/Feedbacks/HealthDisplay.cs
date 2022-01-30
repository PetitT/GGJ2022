using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private List<Image> healthImages;

    private void Start()
    {
        GameManager.Instance.HealthManager.onHealthChanged += HealthManager_onHealthChanged;
        HealthManager_onHealthChanged(GameManager.Instance.HealthManager.health.CurrentHealth);
    }

    private void OnDestroy()
    {
        GameManager.Instance.HealthManager.onHealthChanged += HealthManager_onHealthChanged;
    }

    private void HealthManager_onHealthChanged(int newHealth)
    {
        if (newHealth == GameManager.Instance.Data.CharacterMaxHealth) return;
        healthText.text = newHealth.ToString();
        if (healthImages.Count >= newHealth - 2)
        {
            healthImages[newHealth].gameObject.SetActive(false);
        }
    }
}
