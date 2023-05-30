using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public PlayerMovement playerMovement; // Reference to the PlayerMovement script
    public Button MainMenuButton;

    public bool isPaused;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>(); // Find the PlayerMovement component
        ResumeGame();
        MainMenuButton.onClick.AddListener(MainMenu);
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
    public void MainMenu()
    {
        // Implement the logic to load the main menu scene here
        SceneManager.LoadScene("MainMenu"); // Replace "MainMenu" with the actual name of your main menu scene
    }
    public void QuitGame()
    {
        // Implement your quit game functionality here
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}