using UnityEngine;
using System.Collections;

public class SpeedUp : MonoBehaviour
{
    public MotherCollider colliders;
    [SerializeField]
    public float newSpeed;

	// Use this for initialization
	void Start ()
    {
        colliders = GetComponent<MotherCollider>();
        colliders.Collision += SpeedUP_Collision;
	}

    private void SpeedUP_Collision(MotherCollider obj)
    {
        if (obj.gameObject.tag=="Player")
        {
            obj.GetComponent<Movement>().speed = newSpeed;
        }
    }

    // Update is called once per frame
    void Update ()
    {
	
	}

}
