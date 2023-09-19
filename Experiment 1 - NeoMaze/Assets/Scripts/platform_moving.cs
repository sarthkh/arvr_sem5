using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_moving : MonoBehaviour
{
    // Indicates whether the platform can move or not.
    public bool canMove;

    // Speed at which the platform moves.
    [SerializeField] float speed;

    // Index of the starting point for the platform's movement.
    [SerializeField] int startPoint;

    // Array of positions that define the path for the platform to follow.
    [SerializeField] Transform[] points;

    int i; // Index to keep track of the current point.
    bool reverse; // Indicates whether the platform is moving in reverse.

    void Start()
    {
        // Set the initial position of the platform to the starting point.
        transform.position = points[startPoint].position;
    }

    void Update()
    {
        // Check if the platform is very close to the current target point.
        if (Vector3.Distance(transform.position, points[i].position) < 0.01f)
        {
            canMove = false; // Stop the platform from moving.

            if (i == points.Length - 1)
            {
                reverse = true; // If at the end, reverse the movement.
                i--;
                return; // Exit the Update method.
            }
            else if (i == 0)
            {
                reverse = false; // If at the beginning, move forward.
                i++;
                return; // Exit the Update method.
            }

            // If not at the beginning or end, continue moving based on reverse state.
            if (reverse)
            {
                i--; // Move to the previous point.
            }
            else
            {
                i++; // Move to the next point.
            }
        }

        // If the platform is allowed to move, move it towards the current target point.
        if (canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        }
    }
}
