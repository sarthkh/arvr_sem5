using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject pauseMenuUI;         // Reference to the pause menu UI GameObject.
    public GameObject gameOverScreenUI;   // Reference to the game over screen UI GameObject.

    public static bool GameIsPaused = false;  // Indicates whether the game is currently paused.
    public static bool GameOver = false;      // Indicates whether the game is over.

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameOver)
            {
                return; // If the game is over, do nothing when the Escape key is pressed.
            }
            else if (GameIsPaused)
            {
                Resume(); // If the game is paused, resume gameplay.
            }
            else
            {
                Pause(); // If the game is not paused, pause gameplay.
            }
        }
    }

    public void Resume()
    {
        if (GameOver)
        {
            return; // If the game is over, do nothing when trying to resume.
        }
        pauseMenuUI.SetActive(false);    // Hide the pause menu UI.
        Time.timeScale = 1f;            // Set time scale to normal (unpause).
        GameIsPaused = false;           // Update the pause state.
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);     // Show the pause menu UI.
        Time.timeScale = 0f;            // Set time scale to 0 (pause).
        GameIsPaused = true;            // Update the pause state.
    }

    public void Restart()
    {
        GameOver = false;               // Reset the game over state.
        Time.timeScale = 1f;            // Set time scale to normal.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Reload the current scene.
        GameIsPaused = false;           // Ensure the game is not paused.
        pauseMenuUI.SetActive(false);   // Hide the pause menu UI.
        gameOverScreenUI.SetActive(false); // Hide the game over screen UI.
    }

    public void ExitGame()
    {
        Application.Quit();  // Quit the application.
    }

    public void EndGame()
    {
        GameOver = true;               // Set the game over state.
        gameOverScreenUI.SetActive(true);  // Show the game over screen UI.
        Time.timeScale = 0f;            // Set time scale to 0 (pause).
    }

    void OnTriggerEnter(Collider other)
    {
        if (GameOver)
        {
            return; // If the game is over, do nothing when the trigger is entered.
        }

        if (other.gameObject.name == "Player")
        {
            EndGame(); // Call the EndGame function if the player enters a trigger.
        }
    }
}
