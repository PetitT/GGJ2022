using UnityEngine;

[CreateAssetMenu(menuName = "AI/ZigzagAI")]
public class ZigzagAI : BaseAI
{
    public float speed = 1.0f;
    public Vector2 direction = Vector2.up;
    public float amplitude = 1.0f;

    Vector2 zigDirection;

    public override void Initialize(Transform self, Transform target)
    {
        base.Initialize(self, target);

        direction.Normalize();
    }

    public override void Execute()
    {
        zigDirection = new Vector2(direction.y, -direction.x) * (Mathf.PingPong(Time.time, amplitude * 2.0f) - amplitude);
        zigDirection = Vector3.Normalize(direction + zigDirection);
        self.position += (Vector3)zigDirection * speed * Time.deltaTime;
    }
}
