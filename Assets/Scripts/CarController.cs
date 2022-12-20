using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float moveInput;
    private float turnInput;
    private bool isCarGrounded;

    public float airDrag;
    public float groundDrag;

    public float fwdSpeed;
    public float rvsSpeed;
    public float turnSpeed;
    public LayerMask groundLayer;

    public Rigidbody sphereRB;
    private bool isJump = false;
    public float jumpAmount = 1f;
    public float gravityScale = 5f;
    public float boostAmount = 1f;
    private bool isBoost;

   

    void Start()
    {
        // detach sphere rb from car
        sphereRB.transform.parent = null;
    }

    
    void Update()
    {

        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxisRaw("Horizontal");

        moveInput *= moveInput > 0 ? fwdSpeed : rvsSpeed;

        // set car position to sphere
        transform.position = sphereRB.transform.position;

        // set car rotation
        float newRotation = turnInput * turnSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        transform.Rotate(xAngle: 0, yAngle: newRotation, zAngle: 0, relativeTo: Space.World);

        // raycast ground check
        RaycastHit hit;
        isCarGrounded = Physics.Raycast(origin: transform.position, direction: -transform.up, out hit, maxDistance: 1f, groundLayer);

        // rotate car to make it parallel to ground
        transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;

        if (isCarGrounded)
        {
            sphereRB.drag = groundDrag;
        }
        else
        {
            sphereRB.drag = airDrag;
        }
        if(Input.GetButtonDown("Jump")) {
            isJump = true;
        }
        // add a timer condition after too
        if(Input.GetKeyDown("c")) {
            isBoost = true;
        }

    }

    private void FixedUpdate()
    {

        if (isCarGrounded)
        {
            // move car
            sphereRB.AddForce(transform.forward * moveInput, ForceMode.Acceleration);
        }
        else
        {
            // add extra force
            sphereRB.AddForce(transform.up * -30f);
        }

        if(isJump && isCarGrounded) {
            sphereRB.AddForce(Vector2.up * jumpAmount, ForceMode.Impulse);
            isJump = false;
        }
        if(isBoost) {
            sphereRB.AddForce(transform.forward * boostAmount, ForceMode.Impulse);
            isBoost = false;
        }
        sphereRB.AddForce(Physics.gravity * (gravityScale - 1) * sphereRB.mass);

    }
}
