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
    public float InvulnerabilityTime;

    [Header("Missiles")]
    public GameObject Missile;
    public float MissileFireRate;
    public float MissilesSpeed;

    [Header("Laser")]
    public float LaserSpeed;
    public float LaserScale;
    public float LaserMaxHitDistance;
    public float LaserMinHitDistance;
    public float LaserTickRate;

    [Header("Enemies Spawn")]
    public List<GameObject> EnemiesList;
    public float EnemiesSpawnRate;

    [Header("Walls")]
    public List<GameObject> Walls;
    public AnimationCurve WallSpeedCurve;
    public float WallSpeed;
    public Vector2 TimeBetweenWallsSpawns;

    [Header("FeedBacks")]
    public int ScreenShakeTimeInMiliseconds;
    public float ScreenShakeAmplitude;
    public float ScreenShakeFrequency; 
    public int BigScreenShakeTimeInMiliseconds;
    public float BigScreenShakeAmplitude;
    public float BigScreenShakeFrequency;

    public static GameData GetGameData()
    {
        return Resources.Load<GameData>("GameData");
    }
}
