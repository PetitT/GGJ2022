using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : BaseManager
{
    private List<GameObject> enemiesList => gameData.EnemiesList;
    private float spawnRate => gameData.EnemiesSpawnRate;
    private float remainingSpawnRate;

    public override void OnUpdate()
    {
        Timer.LoopedCountDown(ref remainingSpawnRate, spawnRate, SpawnMinion);        
    }

    private void SpawnMinion()
    {
        var prefab = enemiesList.GetRandom();

        if (prefab.CompareTag("Wave"))
        {
            foreach (Transform item in prefab.transform)
                Pool.Instance.GetItemFromPool(item.gameObject, item.position);
        }
        else
        {
            ScreenBorderSide side;

            if (prefab.GetComponent<TeamedObject>().currentTeam == Team.Blue)
                side = Random.value > 0.5f ? ScreenBorderSide.Left : ScreenBorderSide.Right;
            else
                side = Random.value > 0.5f ? ScreenBorderSide.Top : ScreenBorderSide.Bottom;

            Vector2 spawnPosition = gameManager.CameraBordermanager.GetRandomPointOnScreenBorder(side, 1);
            GameObject newMinion = Pool.Instance.GetItemFromPool(prefab, spawnPosition);
        }
    }
}
