using UnityEngine;

public abstract class BaseAI : ScriptableObject
{
    protected Transform self;
    protected Transform target;

    public virtual void Initialize(Transform self, Transform target)
    {
        this.self = self;
        this.target = target;
    }

    public abstract void Execute();
}
