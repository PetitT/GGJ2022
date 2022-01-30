using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    public GameObject rocketPrefab;
    public float fireRate = 1.0f;
    private float RemainingTimeToLaunch;
    public int ammunition = -1;
    public Direction direction;

    void OnEnable()
    {
        RemainingTimeToLaunch = fireRate;
    }

    public void Update()
    {
        if (ammunition > 0 || ammunition == -1)
            Timer.LoopedCountDown(ref RemainingTimeToLaunch, fireRate, Shoot);
    }

    private void Shoot()
    {
        Vector2 position = transform.position;
        GenerateNewMissile(position, GetDirection());

        SoundManager.Instance.PlayClip(GameManager.Instance.feedbackData.missileShot);

        if (ammunition > 0) ammunition--;
    }

    private void GenerateNewMissile(Vector2 position, Vector2 direction)
    {
        var rocket = Pool.Instance.GetItemFromPool(rocketPrefab, position);
        rocket.transform.up = direction;
    }

    private Vector2 GetDirection()
    {
        switch (direction)
        {
            case Direction.Up: return Vector2.up;
            case Direction.Down: return Vector2.down;
            case Direction.Right: return Vector2.right;
            case Direction.Left: return Vector2.left;
            case Direction.Aimed: return Vector3.Normalize(GameManager.Instance.Character.transform.position - transform.position);
            default: return Vector2.zero;
        }
    }

    public enum Direction
    {
        Up, Down, Right, Left, Aimed
    }
}
