using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "GameData", fileName = "GameData")]
public class GameData : ScriptableObject
{
    [Header("Character")]
    public float CharacterSpeed;
    public float CharacterAcceleration;
    public float CharacterHalfSize;

    public static GameData GetGameData()
    {
        return Resources.Load<GameData>("GameData");
    }
}
