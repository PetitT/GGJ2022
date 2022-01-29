using UnityEngine;

[CreateAssetMenu(menuName = "AI/LinearAI")]
public class LinearAI : BaseAI
{
    public float speed = 1.0f;
    public Vector2 direction = Vector2.up;

    public override void Initialize(Transform self, Transform target)
    {
        base.Initialize(self, target);

        direction.Normalize();
    }

    public override void Execute()
    {
        self.position += (Vector3)direction * speed * Time.deltaTime;
    }
}
