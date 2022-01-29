using UnityEngine;

[CreateAssetMenu(menuName = "AI/PointedAI")]
public class PointedAI : BaseAI
{
    public float speed = 1.0f;
    private Vector2 direction;

    public override void Initialize(Transform self, Transform target)
    {
        base.Initialize(self, target);

        direction = Vector3.Normalize(target.position - self.position);
        Debug.Log(target.position + " " + self.position + " " + direction);
    }

    public override void Execute()
    {
        self.position += speed * Time.deltaTime * (Vector3)direction;
    }
}
