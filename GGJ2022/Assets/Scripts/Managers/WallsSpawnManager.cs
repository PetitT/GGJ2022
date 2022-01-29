using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsSpawnManager : BaseManager
{
    private Vector2 timeBetweenSpawns => gameData.TimeBetweenWallsSpawns;
    private float remainingTimeToWall;
    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}
