using System.Collections;
using UnityEngine;

public class collision_handler : MonoBehaviour
{
    public Color newColor;          // The new color to assign to collided objects.
    public string hexCode = "#DB2955"; // Hexadecimal color code (default value).

    public int pointsToRemove = 5;  // Number of points to remove when colliding with an obstacle.

    private void OnCollisionEnter(Collision collided)
    {
        GameObject other = collided.gameObject; // Get the collided game object.

        if (other.CompareTag("Obstacle"))
        {
            // Change the tag of the collided object to "Collided".
            other.tag = "Collided";

            MeshRenderer meshRenderer = other.GetComponent<MeshRenderer>();

            if (meshRenderer != null)
            {
                // Try to parse the hex color code into a Color object and assign it to newColor.
                ColorUtility.TryParseHtmlString(hexCode, out newColor);

                // Set the material color of the collided object to the new color.
                meshRenderer.material.color = newColor;
            }

            // Find the player_score script in the scene.
            player_score playerScore = FindObjectOfType<player_score>();

            if (playerScore != null)
            {
                // Reduce the player's score by the specified number of points.
                playerScore.ReducePoints(pointsToRemove);
            }
        }
    }
}
