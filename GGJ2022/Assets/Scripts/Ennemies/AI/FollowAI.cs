using UnityEngine;

[CreateAssetMenu(menuName = "AI/FollowAI")]
public class FollowAI : BaseAI
{
    public float speed = 1.0f;
    private Vector2 direction;

    public override void Execute()
    {
        direction = Vector3.Normalize(target.position - self.position);
        self.position += speed * Time.deltaTime * (Vector3)direction;
    }
}
