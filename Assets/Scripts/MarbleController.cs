using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleController : MonoBehaviour
{

    public Rigidbody RB;
    public float moveSpeed = 10f; // speed on the ground
    public float airSpeed = 10f; // speed in the air
    public float appliedSpeed = 0f; // actual force put on the marble

    private float xInput;
    private float zInput;
    private bool isCarGrounded;
    private bool isJump = false;
    public float jumpAmount = 1f;
    public float gravityScale = 5f;
    public LayerMask groundLayer;

    public Transform bottom;

    public Transform cam;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        ProcessInputs();

    }

    private void FixedUpdate()
    {
        Move();

        if(isJump && isCarGrounded) {
            RB.AddForce(Vector2.up * jumpAmount, ForceMode.Impulse);
            isJump = false;
        }

        RB.AddForce(Physics.gravity * (gravityScale - 1) * RB.mass);
    }

    private void ProcessInputs()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        // Change so it raycasts only the bottom of the sphere -- NO WALL JUMPING!
        isCarGrounded = Physics.CheckSphere(transform.position, 1.1f, groundLayer);


        if(Input.GetButtonDown("Jump") && isCarGrounded) {
            isJump = true;
        }
    }

    private void Move()
    {
        Vector3 direction = new Vector3(xInput, 0f, zInput).normalized;

        if(direction.magnitude >= 1) {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            Vector3 movDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            appliedSpeed = (isCarGrounded == true) ? moveSpeed : airSpeed;
            RB.AddForce(movDir * appliedSpeed);
        }
    }
}
