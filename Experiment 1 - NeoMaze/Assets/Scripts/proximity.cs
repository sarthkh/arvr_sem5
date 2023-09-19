using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proximity : MonoBehaviour
{
    // An array to store the objects affected by proximity
    public GameObject[] affectedObjects;

    // Reference to the player GameObject
    public GameObject player;

    // An array to store the Rigidbody components of affected objects
    private Rigidbody[] affectedRigidbodies;

    void Start()
    {
        // Initialize the array of affectedRigidbodies with the same length as affectedObjects
        affectedRigidbodies = new Rigidbody[affectedObjects.Length];

        // Loop through each affected object
        for (int i = 0; i < affectedObjects.Length; i++)
        {
            GameObject affectedObject = affectedObjects[i];

            // Check if the affectedObject exists
            if (affectedObject != null)
            {
                // Get the Rigidbody component of the affectedObject
                Rigidbody rb = affectedObject.GetComponent<Rigidbody>();

                // Check if a Rigidbody component was found
                if (rb != null)
                {
                    // Store the Rigidbody component in the affectedRigidbodies array
                    affectedRigidbodies[i] = rb;
                }
                else
                {
                    // Log a warning if the affectedObject does not have a Rigidbody component
                    Debug.LogWarning("Affected object does not have a Rigidbody component.");
                }
            }
            else
            {
                // Log a warning if the affectedObject is not assigned
                Debug.LogWarning("Affected object is not assigned.");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the triggering object is the player
        if (other.gameObject == player)
        {
            // Loop through each affected Rigidbody
            for (int i = 0; i < affectedRigidbodies.Length; i++)
            {
                Rigidbody rb = affectedRigidbodies[i];
                if (rb != null)
                {
                    // Enable gravity for the affected Rigidbody
                    rb.useGravity = true;
                }
            }
        }
    }
}
