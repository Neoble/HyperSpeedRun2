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

    MotherCollider collider;
    Vector3D StartVector;
    Vector3D UpdatePosition;
    // Use this for initialization
    void Start()
    {
        StartVector = new Vector3D(0, 1, 0);
        collider = GetComponent<MotherCollider>();
        gameObject.transform.position = StartVector;
        speed = 0.01f;
        fallingSpeed = 0.1f;
        moveSpeedLeft = 0.1f;
        moveSpeedRight = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!collider.grounded)
        {
            this.gameObject.transform.position = Vector3D.Falling(this.gameObject, fallingSpeed);
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
        else if (Input.GetKey(KeyCode.W) && collider.grounded)
        {
            UpdatePosition = Vector3D.Position(this.gameObject);
            this.gameObject.transform.position = StartVector.Translate(new Vector3D(UpdatePosition.x, this.gameObject.transform.position.y + 10 * Time.deltaTime, UpdatePosition.z));
        }
        UpdatePosition = Vector3D.Position(this.gameObject);
        this.transform.position = StartVector.Translate(new Vector3D(UpdatePosition.x, UpdatePosition.y, this.gameObject.transform.position.z + speed));
    }

}