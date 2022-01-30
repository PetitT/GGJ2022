using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : BaseManager
{
    public event Action<int> onScoreChanged;
    public int currentScore { get; private set; }

    public override void OnAwake()
    {
        Enemy.onDeath += AddScore;
    }

    public void AddScore(Enemy sender)
    {
        currentScore += sender.score;
        onScoreChanged?.Invoke(currentScore);
    }
}
