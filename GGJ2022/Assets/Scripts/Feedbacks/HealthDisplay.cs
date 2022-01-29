using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;

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
        healthText.text = newHealth.ToString();
    }
}
