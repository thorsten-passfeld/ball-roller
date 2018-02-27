using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpSpeed;
    private float distanceToGround;
    private Rigidbody rb;
    private GameObject SceneCamera;

    void Start()
    {
        SceneCamera = GameObject.Find("Main Camera");
        rb = GetComponent<Rigidbody>();
        distanceToGround = GetComponent<Collider>().bounds.extents.y;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
            rb.AddForce(Vector3.up * jumpSpeed * Time.deltaTime * 100);
    }

	//Fixed Update wegen der Benutzung von "Rigidbody"
	void FixedUpdate ()
    {
        //Input Check
        float movementHorizontal =  Input.GetAxis("Horizontal");
        float movementVertical =  Input.GetAxis("Vertical");

        //Move in relation to the Camera
        Vector3 movementVector = new Vector3(movementHorizontal, 0f, movementVertical);
        movementVector = SceneCamera.transform.TransformDirection(movementVector);

            rb.AddForce(movementVector * speed * Time.deltaTime);

    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distanceToGround + 0.3f);
    }
}