using UnityEngine;

[CreateAssetMenu(menuName = "AI/OrbitalAI")]
public class OrbitalAI : BaseAI
{
    public float speed = 1.0f;
    public float radius = 5.0f;
    public int orbitalDirection = 1;

    Vector3 targetpos;

    public override void Execute()
    {
        //this is working don't ask
        targetpos = target.position + Quaternion.Euler(0.0f, 0.0f, 5.0f * speed * Mathf.Sign(orbitalDirection)) * (self.position - target.position).normalized * radius;

        self.position = Vector3.MoveTowards(self.position, targetpos, speed * Time.deltaTime);
        Debug.DrawLine(self.position, targetpos);
    }
}
