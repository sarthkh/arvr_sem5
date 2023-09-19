using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Public variables for controlling movement
    public float horizontalInput;
    public float verticalInput;
    public float turnspeed = 75;

    // Reference to the Rigidbody component
    public Rigidbody rb;

    // Boolean to track whether the cube is on the ground
    public bool cubeIsOnTheGround = true;

    void Start()
    {
        // Get the Rigidbody component attached to this GameObject
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Read input for horizontal and vertical movement
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Translate the cube's position based on input
        transform.Translate(0, 0, Time.deltaTime * verticalInput * 4);

        // Rotate the cube based on horizontal input
        transform.Rotate(Vector3.up * horizontalInput * turnspeed * Time.deltaTime);

        // Check if the Jump button is pressed and the cube is on the ground
        if (Input.GetButtonDown("Jump") && cubeIsOnTheGround)
        {
            // Apply an upward force to make the cube jump
            rb.AddForce(new Vector3(0, 4.5f, 0), ForceMode.Impulse);

            // Update the flag to indicate the cube is in the air
            cubeIsOnTheGround = false;
        }
    }

    // Collision event handler when the cube collides with other objects
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an object tagged as "Floor"
        if (collision.gameObject.tag == "Floor")
        {
            // Set the flag to indicate that the cube is on the ground
            cubeIsOnTheGround = true;
        }
    }
}
