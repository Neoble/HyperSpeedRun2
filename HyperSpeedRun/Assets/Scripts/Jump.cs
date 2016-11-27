using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour
{
    public MotherCollider colliders;
    Vector3D UpdatePosition;
    public float jumpHeight;
    public Animator _animator;
    // Use this for initialization
    void Start()
    {
        colliders = GetComponent<MotherCollider>();
        colliders.Collision += Jump_Collision;
        jumpHeight = 120.0f;
        _animator = GetComponent<Animator>();
    }

    private void Jump_Collision(MotherCollider obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            obj.transform.Translate(new Vector3D(UpdatePosition.x, obj.gameObject.transform.position.y + jumpHeight * Time.deltaTime, UpdatePosition.z));
            _animator.SetTrigger("istriggered");
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}


