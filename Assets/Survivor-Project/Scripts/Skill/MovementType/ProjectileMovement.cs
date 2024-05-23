using UnityEngine;
public class ProjectileMovement : IMovementStrategy
{
    public void Move(Rigidbody rb, Transform transform, int speed)
    {
        rb.velocity = transform.forward * speed;
    }
}
