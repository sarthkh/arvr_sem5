// Import necessary libraries.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Create a class called parent_platform that inherits from MonoBehaviour.
public class parent_platform : MonoBehaviour
{
    // This method is called when a collision occurs.
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object colliding with this platform is not the "Player" object.
        if (collision.gameObject.name != "Player")
        {
            // Set the parent of the colliding object to this platform, making it move with the platform.
            collision.transform.SetParent(transform);
        }
    }

    // This method is called when a collision with this platform ends.
    private void OnCollisionExit(Collision collision)
    {
        // Set the parent of the colliding object to null, removing it from the platform.
        collision.transform.SetParent(null);
    }
}
