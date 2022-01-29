using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAttack 
{
    public virtual void Begin() { }
    public virtual void Stop() { }
    public abstract void Update();
}
