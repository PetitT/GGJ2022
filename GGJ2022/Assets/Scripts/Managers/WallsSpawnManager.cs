using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsSpawnManager : BaseManager
{
    private Vector2 timeBetweenSpawns => gameData.TimeBetweenWallsSpawns;
    private float remainingTimeToWall;

    public override void OnAwake()
    {
        remainingTimeToWall = 5f;
    }

    public override void OnUpdate()
    {
        Timer.LoopedCountDown(ref remainingTimeToWall, timeBetweenSpawns.RandomRange(), SpawnWall);
    }

    private void SpawnWall()
    {

    }
}
