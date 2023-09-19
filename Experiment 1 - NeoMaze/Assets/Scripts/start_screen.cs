using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject StartButton; // Reference to the StartButton GameObject in the Unity Editor
    private bool GameStarted = false; // Flag to track whether the game has started

    void Start()
    {
        Time.timeScale = 0f; // Set the time scale to 0 to pause the game at the start
    }

    public void StartGame()
    {
        if (!GameStarted) // Check if the game has not already started
        {
            Time.timeScale = 1f; // Set the time scale to 1 to resume the game
            GameStarted = true; // Update the flag to indicate that the game has started

            StartButton.SetActive(false); // Deactivate the StartButton GameObject to hide it
        }
    }
}
