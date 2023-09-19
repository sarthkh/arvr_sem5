using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_platform : MonoBehaviour
{
    // Declare a reference to the platform_moving script
    platform_moving platform;

    private void Start()
    {
        // Get a reference to the platform_moving script attached to this GameObject
        platform = GetComponent<platform_moving>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // When a Collider enters the trigger zone of this GameObject, set canMove to true in the platform_moving script.
        platform.canMove = true;
    }
}
