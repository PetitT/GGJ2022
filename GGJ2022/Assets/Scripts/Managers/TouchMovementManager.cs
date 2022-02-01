using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMovementManager : BaseManager
{
    private Vector2 InitialInput;
    private Vector2 InitialCharacterPosition;
    private Vector2 CurrentInput;
    private Vector2 CurrentTarget;

    private float minimumMagnitudeToMove = 0.1f;

    private Camera cam;

    private float Speed => gameData.CharacterSpeed;
    private float Acceleration => gameData.CharacterAcceleration;
    private float CharacterHalfSize => gameData.CharacterHalfSize;

    private float currentSpeed;
    private float targetSpeed;

    public override void OnAwake()
    {
        gameManager.TouchInputManager.onInputDrag += TouchInputManager_onInputDrag;
        gameManager.TouchInputManager.onInputPress += TouchInputManager_onInputPress;
        gameManager.TouchInputManager.onInputRelease += TouchInputManager_onInputRelease;

        cam = Camera.main;
    }

    private void TouchInputManager_onInputPress(Vector2 obj)
    {
        InitialInput = cam.ScreenToWorldPoint(obj);
        InitialCharacterPosition = gameManager.Character.transform.position;
        CurrentInput = cam.ScreenToWorldPoint(obj);
        targetSpeed = Speed;
    }

    private void TouchInputManager_onInputDrag(Vector2 obj)
    {
        CurrentInput = cam.ScreenToWorldPoint(obj);
    }

    private void TouchInputManager_onInputRelease(Vector2 obj)
    {
        targetSpeed = 0;
    }

    public override void OnUpdate()
    {
        CheckDestination();
        Accelerate();
        MoveCharacter();
        ClampCharacterToScreen();
    }

    private void CheckDestination()
    {
        Vector2 InputDelta = CurrentInput - InitialInput;
        if (InputDelta.magnitude < minimumMagnitudeToMove)
        {
            InputDelta = Vector2.zero;
        }

        CurrentTarget = InitialCharacterPosition + InputDelta;
    }

    private void Accelerate()
    {
        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, Acceleration * Time.deltaTime);
    }
    private void MoveCharacter()
    {
        gameManager.Character.transform.position = Vector2.MoveTowards(gameManager.Character.transform.position, CurrentTarget, currentSpeed * Time.deltaTime);
    }

    private void ClampCharacterToScreen()
    {
        Vector2 localPosition = gameManager.Character.transform.position;
        Vector2 screenBounds = GameManager.Instance.CameraBordermanager.screenBounds;
        float clampedX = Mathf.Clamp(localPosition.x, -screenBounds.x + CharacterHalfSize, screenBounds.x - CharacterHalfSize);
        float clampedY = Mathf.Clamp(localPosition.y, -screenBounds.y + CharacterHalfSize, screenBounds.y - CharacterHalfSize);
        Vector2 newPosition = new Vector2(clampedX, clampedY);
        gameManager.Character.transform.position = newPosition;
    }

}
