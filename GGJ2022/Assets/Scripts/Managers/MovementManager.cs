using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : BaseManager
{
    private GameObject character => gameManager.Character;
    private float Speed => gameData.CharacterSpeed;
    private float Acceleration => gameData.CharacterAcceleration;
    private float directionChangeAcceleration => gameData.CharacterDirectionChangeAcceleration;
    private float CharacterHalfSize => gameData.CharacterHalfSize;

    private float currentSpeed;
    private float targetSpeed;

    private Vector2 currentDirection;
    private Vector2 targetDirection;

    public override void OnAwake()
    {
        gameManager.InputManager.onMove += InputManager_onMove;
    }

    public override void OnUpdate()
    {
        MoveCharacter();
        Accelerate();
        UpdateDirection();
        ClampCharacterPosition();
    }
    private void InputManager_onMove(Vector2 obj)
    {
        obj = obj.normalized;

        if (obj == Vector2.zero)
        {
            targetSpeed = 0;
        }
        else
        {
            targetSpeed = Speed;
        }
        targetDirection = obj;
    }


    private void MoveCharacter()
    {
        character.transform.Translate(currentSpeed * Time.deltaTime * currentDirection);
    }

    private void Accelerate()
    {
        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, Acceleration * Time.deltaTime);
    }

    private void UpdateDirection()
    {
        currentDirection = Vector2.MoveTowards(currentDirection, targetDirection, directionChangeAcceleration * Time.deltaTime);
    }

    private void ClampCharacterPosition()
    {
        Vector2 localPosition = character.transform.position;
        Vector2 screenBounds = GameManager.Instance.CameraBordermanager.screenBounds;
        float clampedX = Mathf.Clamp(localPosition.x, -screenBounds.x + CharacterHalfSize, screenBounds.x - CharacterHalfSize);
        float clampedY = Mathf.Clamp(localPosition.y, -screenBounds.y + CharacterHalfSize, screenBounds.y - CharacterHalfSize);
        Vector2 newPosition = new Vector2(clampedX, clampedY);
        character.transform.position = newPosition;
    }


}
