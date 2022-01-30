using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : BaseManager
{
    public event Action<Vector2> onMove;
    public event Action onSpaceInput;

    private float XInput;
    private float YInput;

    public override void OnUpdate()
    {
        CheckMovementInput();
        CheckSpaceInput();
    }

    private void CheckMovementInput()
    {
        XInput = Input.GetAxisRaw("Horizontal");
        YInput = Input.GetAxisRaw("Vertical");

        onMove?.Invoke(new Vector2(XInput, YInput));
    }

    private void CheckSpaceInput()
    {
        if (Input.GetButtonDown("Jump"))
        {
            onSpaceInput?.Invoke();
        }
    }
}
