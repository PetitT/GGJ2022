using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : BaseManager
{
    public event Action<int> onScoreChanged;
    public int currentScore { get; private set; }
    private int scorePerKill => gameData.ScorePerKill;

    public override void OnAwake()
    {
        
    }

    private void AddScore()
    {
        currentScore += scorePerKill;
        onScoreChanged?.Invoke(currentScore);
    }
}
