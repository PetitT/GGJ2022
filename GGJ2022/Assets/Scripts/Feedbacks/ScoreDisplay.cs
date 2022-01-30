using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private void Start()
    {
        GameManager.Instance.ScoreManager.onScoreChanged += ScoreManager_onScoreChanged;
        GameManager.Instance.HealthManager.onDeath += HealthManager_onDeath;
        ScoreManager_onScoreChanged(0);
    }

    private void OnDestroy()
    {
        GameManager.Instance.ScoreManager.onScoreChanged -= ScoreManager_onScoreChanged;
        GameManager.Instance.HealthManager.onDeath -= HealthManager_onDeath;
    }

    private void ScoreManager_onScoreChanged(int obj)
    {
        scoreText.text = obj.ToString();
    }

    private void HealthManager_onDeath()
    {
        scoreText.rectTransform.DOMove(new Vector2(Screen.width / 2.0f, Screen.height / 2.0f), 2.0f).SetEase(Ease.InOutQuad);
        DOTween.To(() => scoreText.fontSize, v => scoreText.fontSize = v, 100.0f, 2.0f).SetEase(Ease.InOutQuad);
        scoreText.DOFade(0.0f, 1.0f).SetDelay(3.0f);
    }
}
