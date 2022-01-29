using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsSpawnManager : BaseManager
{
    private List<GameObject> walls => gameData.Walls;
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
        ScreenBorderSide side = EnumExtensions.GetRandomEnum<ScreenBorderSide>();
        Vector2 SpawnPosition = gameManager.CameraBordermanager.GetRandomPointOnScreenBorderClampedFromCenter(side, 0, 1);
        GameObject newWall = Pool.Instance.GetItemFromPool(walls.GetRandom(), SpawnPosition);
        Vector2 newUp = new Vector2();

        switch (side)
        {
            case ScreenBorderSide.Top:
                newUp = new Vector2(0, -1);
                break;
            case ScreenBorderSide.Bottom:
                newUp = new Vector2(0, 1);
                break;
            case ScreenBorderSide.Right:
                newUp = new Vector2(-1, 0);
                break;
            case ScreenBorderSide.Left:
                newUp = new Vector2(1, 0);
                break;
            default:
                break;
        }

        newWall.transform.up = newUp;
    }
}
