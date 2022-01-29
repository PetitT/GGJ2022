using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "GameData", fileName = "GameData")]
public class GameData : ScriptableObject
{
    [Header("Character")]
    public float CharacterSpeed;
    public float CharacterAcceleration;
    public float CharacterDirectionChangeAcceleration;
    public float CharacterHalfSize;
    public int CharacterMaxHealth;

    [Header("Missiles")]
    public GameObject Missile;
    public float MissileFireRate;
    public float MissilesSpeed;

    [Header("Laser")]
    public float LaserSpeed;
    public float LaserScale;

    public static GameData GetGameData()
    {
        return Resources.Load<GameData>("GameData");
    }
}
