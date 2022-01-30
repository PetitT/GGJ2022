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

        if (!prefab.CompareTag("Wave"))
        {
            Vector2 spawnPosition = gameManager.CameraBordermanager.GetRandomPointOnScreenBorder(EnumExtensions.GetRandomEnum<ScreenBorderSide>(), 1);
            GameObject newMinion = Pool.Instance.GetItemFromPool(prefab, spawnPosition);
        }
        else
        {
            foreach (Transform item in prefab.transform)
            {
                Pool.Instance.GetItemFromPool(item.gameObject, item.position);
            }
        }
    }
}
