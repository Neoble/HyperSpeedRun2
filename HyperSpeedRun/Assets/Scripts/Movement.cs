using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    [SerializeField]
    public float speed;
    [SerializeField]
    public float fallingSpeed;
    [SerializeField]
    public float moveSpeedRight;
    [SerializeField]
    public float moveSpeedLeft;
    [SerializeField]
    public float jumpHeight;
    public float timer;

    MotherCollider colliders;
    Vector3D StartVector;
    Vector3D UpdatePosition;
    // Use this for initialization
    void Start()
    {
        StartVector = new Vector3D(0, 2, 0);
        colliders = GetComponent<MotherCollider>();
        gameObject.transform.position = StartVector;
        moveSpeedLeft = 0.1f;
        moveSpeedRight = 0.1f;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!colliders.grounded)
        {
            timer += Time.deltaTime;
            if (timer > 0.14f)
            {
                this.gameObject.transform.position = Vector3D.Falling(this.gameObject, fallingSpeed);
            }
        }
        if (colliders.grounded)
        {
            timer = 0f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            UpdatePosition = Vector3D.Position(this.gameObject);
            this.gameObject.transform.position = StartVector.Translate(new Vector3D(this.gameObject.transform.position.x + moveSpeedRight, UpdatePosition.y, UpdatePosition.z));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            UpdatePosition = Vector3D.Position(this.gameObject);
            this.gameObject.transform.position = StartVector.Translate(new Vector3D(this.gameObject.transform.position.x - moveSpeedLeft, UpdatePosition.y, UpdatePosition.z));
        }
        UpdatePosition = Vector3D.Position(this.gameObject);
        this.transform.position = StartVector.Translate(new Vector3D(UpdatePosition.x, UpdatePosition.y, (this.gameObject.transform.position.z + speed*Time.deltaTime)));
    }


}
