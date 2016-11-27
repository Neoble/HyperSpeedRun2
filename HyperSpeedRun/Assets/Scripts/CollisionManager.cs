using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollisionManager : MonoBehaviour
{
    CollisionManager()
    {

    }

    public List<MotherCollider> Collisionboxes = new List<MotherCollider>();
    public List<MotherCollider> RemovedColliders = new List<MotherCollider>();
    public List<MotherCollider> AddedColliders = new List<MotherCollider>();

    void Update()
    {
        Collisionboxes.AddRange(AddedColliders);
        AddedColliders.Clear();
        foreach (var ColliderA in Collisionboxes)
        {
            ColliderA.grounded = false;
            foreach (var ColliderB in Collisionboxes)
            {
                if (ColliderA != ColliderB)
                {
                    bool colliding = false;
                    if (ColliderA is SphereCollider && ColliderB is SphereCollider)
                    {
                        colliding = HandleCollision((SphereCollider)ColliderA, (SphereCollider)ColliderB);
                    }
                    else if (ColliderA is BoxCollider && ColliderB is BoxCollider)
                    {
                        colliding = HandleCollision((BoxCollider)ColliderA, (BoxCollider)ColliderB);
                    }
                    else if (ColliderA is SphereCollider && ColliderB is BoxCollider)
                    {
                        colliding = HandleCollision((SphereCollider)ColliderA, (BoxCollider)ColliderB);
                    }
                    else if (ColliderA is BoxCollider && ColliderB is SphereCollider)
                    {
                        colliding = HandleCollision((SphereCollider)ColliderB,(BoxCollider) ColliderA);
                    }

                    if (colliding)
                    {
                        ColliderA.OnCollision(ColliderB);
                    }
                }
            }
        }
        foreach (var item in RemovedColliders)
        {
            Collisionboxes.Remove(item);
            Destroy(item.gameObject);
        }
        RemovedColliders.Clear();
    }

    private static bool HandleCollision(SphereCollider ColliderA, SphereCollider ColliderB)
    {
        return  (ColliderA.WorldCenter-ColliderB.WorldCenter).Magnitude()< ColliderA.SphereRadius + ColliderB.SphereRadius ;
    }
    private static bool HandleCollision(SphereCollider ColliderA, BoxCollider ColliderB)
    {
        float distanceX;
        float distanceY;
        float distanceZ;
        //closest Point to sphere center
        distanceX = Mathf.Max(ColliderB.WorldLeft, Mathf.Min(ColliderA.WorldCenter.x, ColliderB.WorldRight));
        distanceY = Mathf.Max(ColliderB.WorldBottom, Mathf.Min(ColliderA.WorldCenter.y, ColliderB.WorldTop));
        distanceZ = Mathf.Max(ColliderB.WorldFront, Mathf.Min(ColliderA.WorldCenter.z, ColliderB.WorldBack));

        float distance = Mathf.Sqrt((distanceX - ColliderA.WorldCenter.x) * (distanceX - ColliderA.WorldCenter.x) + (distanceY - ColliderA.WorldCenter.y) * (distanceY - ColliderA.WorldCenter.y) + (distanceZ - ColliderA.WorldCenter.z) * (distanceZ - ColliderA.WorldCenter.z));

        return distance < ColliderA.SphereRadius;
    }

    private static bool HandleCollision(BoxCollider ColliderA, BoxCollider ColliderB)
    {
        return ColliderA.WorldLeft <= ColliderB.WorldRight && ColliderA.WorldRight >= ColliderB.WorldLeft && ColliderA.WorldBottom <= ColliderB.WorldTop && ColliderA.WorldTop >= ColliderB.WorldBottom && ColliderA.WorldFront <= ColliderB.WorldBack && ColliderA.WorldBack >= ColliderB.WorldFront;
    }

}
