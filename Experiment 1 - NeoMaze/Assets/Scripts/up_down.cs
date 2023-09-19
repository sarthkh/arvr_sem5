using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class up_down : MonoBehaviour
{
    public float speed = 3;          // Speed of up and down movement
    public float lower_limit = 0.5f; // Lower limit for movement
    public float upper_limit = 10;   // Upper limit for movement

    // Variable to control the direction of movement (1 for up, -1 for down)
    int sign = 1;

    void Update()
    {
        // Get the current vertical position of the GameObject
        float pos = transform.localPosition.y;

        // Check if the position is below the lower limit
        if (pos < lower_limit)
            sign = 1; // Change the direction to move up

        // Check if the position is above the upper limit
        if (pos > upper_limit)
            sign = -1; // Change the direction to move down

        // Translate the GameObject vertically based on speed and direction
        transform.Translate(0, sign * speed * Time.deltaTime, 0);
    }
}
