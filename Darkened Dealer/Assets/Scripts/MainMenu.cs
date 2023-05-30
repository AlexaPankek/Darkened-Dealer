using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        // Show and unlock the cursor in the main menu
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayGame()
    {
        // Load the game scene
        SceneManager.LoadScene("DarkenedDealer");
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }
}