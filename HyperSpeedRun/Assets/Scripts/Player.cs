using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    MotherCollider colliders;

	// Use this for initialization
	void Start ()
    {
        colliders = GetComponent<MotherCollider>();
        colliders.Collision += Player_Collision;
    }

    private void Player_Collision(MotherCollider obj)
    {
        if (obj.gameObject.layer == 8)
        {
            colliders.grounded = true;
        }
        else
            colliders.enabled = false;
    
    }

    // Update is called once per frame
    void Update ()
    {
        if (this.gameObject.transform.position.y<0)
        {
            colliders.enabled = false;
            SceneManager.LoadScene("LooseScene");
        }
	}
}
