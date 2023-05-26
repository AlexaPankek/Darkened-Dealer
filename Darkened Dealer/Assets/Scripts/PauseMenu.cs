using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public PlayerMovement playerMovement; // Reference to the PlayerMovement script

    public bool isPaused;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>(); // Find the PlayerMovement component
        ResumeGame();
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Pause the game
        pauseMenuPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Disallow player rotation
        playerMovement.AllowRotation(false);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Resume normal time
        pauseMenuPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Allow player rotation
        playerMovement.AllowRotation(true);
    }

    public void QuitGame()
    {
        // Implement your quit game functionality here
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}