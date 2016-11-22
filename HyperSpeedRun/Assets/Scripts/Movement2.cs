using UnityEngine;
using System.Collections;

public class Movement2 : MonoBehaviour
{
    public Vector3 acceleration;

    private Vector3 velocity;

    public float bounciness = 0.9f;

    void FixedUpdate()
    {
        Vector3 speedDiff = acceleration * Time.fixedDeltaTime;
        velocity = velocity + speedDiff;

        Vector3 posDiff = velocity * Time.fixedDeltaTime;

        this.transform.Translate(posDiff);
    }

    void OnCollisionEnter(Collision collision)
    {
        OnCollisionWithWall(collision);
    }

    void OnCollisionWithWall(Collision collision)
    {
        velocity = new Vector3(velocity.x, -velocity.y * bounciness, velocity.z);
    }
}
