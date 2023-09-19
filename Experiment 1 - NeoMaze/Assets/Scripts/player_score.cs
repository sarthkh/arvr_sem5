using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class player_score : MonoBehaviour
{
    // References to UI elements and variables
    public TMP_Text scoreText; // Text field to display the player's score
    public GameObject gameOverScreen; // Screen to display when the game is over

    private int currentScore; // The player's current score

    private void Start()
    {
        // Initialize the player's score to 50 (you can change this as needed)
        currentScore = 50;

        // Disable the game over screen at the start (if it's not null)
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);
        }

        // Update the score text on the UI
        UpdateScoreText();
    }

    // Reduce the player's score by a specified amount
    public void ReducePoints(int amount)
    {
        currentScore -= amount;

        // Ensure the score doesn't go below zero
        if (currentScore <= 0)
        {
            currentScore = 0;
            UpdateScoreText();
            // Trigger the game over event
            GameOver();
        }
        else
        {
            UpdateScoreText();
        }
    }

    // Handle the game over event
    public void GameOver()
    {
        // Enable the game over screen (if it's not null)
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
        }

        // Pause the game by setting the time scale to zero
        Time.timeScale = 0;

        // Set the Game Over flag in the GameManagerScript to true
        GameManagerScript.GameOver = true;
    }

    // Restart the game
    public void RestartGame()
    {
        // Prevent restarting the game if it's already game over
        if (GameManagerScript.GameOver)
        {
            return;
        }

        // Resume normal time scale
        Time.timeScale = 1;

        // Reload the current scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Update the score text on the UI
    private void UpdateScoreText()
    {
        // Update the displayed score on the UI
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore;
        }
    }
}
