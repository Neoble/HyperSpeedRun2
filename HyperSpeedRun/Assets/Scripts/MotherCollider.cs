using UnityEngine;
using System.Collections;
using System;

public abstract class MotherCollider : MonoBehaviour
{
    public event Action<MotherCollider> Collision;
    public bool grounded;
    public Vector3D Center;
    public Vector3D WorldCenter { get { return transform.position + Center; } }

    private void OnEnable()
    {
        FindObjectOfType<CollisionManager>().AddedColliders.Add(this);
    }
    private void OnDisable()
    {
        FindObjectOfType<CollisionManager>().RemovedColliders.Add(this);
    }

    public void OnCollision(MotherCollider other)
    {
        if (Collision != null)
        {
            Collision(other);
        }
    }

}