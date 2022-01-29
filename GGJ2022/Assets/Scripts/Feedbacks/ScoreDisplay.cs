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
        ScoreManager_onScoreChanged(0);
    }

    private void OnDestroy()
    {
        GameManager.Instance.ScoreManager.onScoreChanged -= ScoreManager_onScoreChanged;
    }

    private void ScoreManager_onScoreChanged(int obj)
    {
        scoreText.text = obj.ToString();
    }
}
