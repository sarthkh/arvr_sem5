using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class left_right : MonoBehaviour
{
    public float speed = 3;         // The speed at which the object moves
    public float lower_limit = 0.5f;  // The lower limit for object's position
    public float upper_limit = 10;    // The upper limit for object's position

    // Variable to determine the direction of movement (-1 for left, 1 for right)
    int sign = 1;

    void Update()
    {
        // Get the current position of the object on the Z-axis
        float pos = transform.localPosition.z;

        // Check if the position is below the lower limit
        if (pos < lower_limit)
            sign = 1; // Change direction to move right

        // Check if the position is above the upper limit
        if (pos > upper_limit)
            sign = -1; // Change direction to move left

        // Translate (move) the object horizontally based on the direction, speed, and frame time
        transform.Translate(sign * speed * Time.deltaTime, 0, 0);
    }
}
