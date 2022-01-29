using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseManager
{
    protected GameManager gameManager => GameManager.Instance;
    protected GameData gameData => gameManager.Data;

    public virtual void OnAwake() { }
    public virtual void OnBegin() { }
    public virtual void OnUpdate() { }
}
