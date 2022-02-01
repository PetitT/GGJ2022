using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInputManager : BaseManager
{
    public event Action<Vector2> onInputPress;
    public event Action<Vector2> onInputDrag;
    public event Action<Vector2> onInputRelease;

    public event Action onButtonClick;

    public override void OnAwake()
    {
        gameManager.SwapButton.onClick.AddListener(SwapTeam);
    }

    public override void OnUpdate()
    {
        CheckTouchInputs();
    }

    private void CheckTouchInputs()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                onInputPress?.Invoke(touch.position);
            }
            if (touch.phase == TouchPhase.Moved)
            {
                onInputDrag?.Invoke(touch.position);
            }
            if (touch.phase == TouchPhase.Ended)
            {
                onInputRelease?.Invoke(touch.position);
            }
        }
    }

    private void SwapTeam()
    {
        onButtonClick?.Invoke();
    }

}
