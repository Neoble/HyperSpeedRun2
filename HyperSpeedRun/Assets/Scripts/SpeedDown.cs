using UnityEngine;
using System.Collections;

public class SpeedDown : MonoBehaviour
{
    MotherCollider colliders;
    [SerializeField]
    public float newSpeed;

    // Use this for initialization
    void Start()
    {
        colliders = GetComponent<MotherCollider>();
        colliders.Collision += SpeedDown_Collision;
    }

    private void SpeedDown_Collision(MotherCollider obj)
    {
        if (obj.CompareTag("Player"))
        {
            obj.GetComponent<Movement>().speed = newSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
