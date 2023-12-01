using UnityEngine;
using UnityEngine.UI;

public class SimplePauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    void Start()
    {
        SetPauseMenuActive(false); // Ensure pauseMenuUI starts as inactive

        // Try to find the Resume button in the pause menu during runtime
        Button resumeButton = FindResumeButton();
        if (resumeButton != null)
        {
            // Attach the Click event to the ResumeGame method
            resumeButton.onClick.AddListener(ResumeGame);
        }
        else
        {
            Debug.LogError("Resume button not found in the pause menu!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    void TogglePauseMenu()
    {
        if (pauseMenuUI != null)
        {
            bool isPaused = !pauseMenuUI.activeSelf;
            SetPauseMenuActive(isPaused);

            // Pause or resume the game based on the menu state
            if (isPaused)
            {
                Time.timeScale = 0f; // Pause the game
                Debug.Log("Game Paused");
            }
            else
            {
                Time.timeScale = 1f; // Resume the game
                Debug.Log("Game Resumed");
            }
        }
    }

    void SetPauseMenuActive(bool isActive)
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(isActive);
            Debug.Log("Setting pauseMenuUI to " + (isActive ? "active" : "inactive"));
        }
        else
        {
            Debug.LogError("pauseMenuUI is not assigned!");
        }
    }

    // Method to be called when the Resume button is clicked
    void ResumeGame()
    {
        Time.timeScale = 1f; // Resume the game
        SetPauseMenuActive(false); // Hide the pause menu
        Debug.Log("Game Resumed (Button Click)");
    }

    // Helper method to find the Resume button in the pause menu during runtime
    Button FindResumeButton()
    {
        if (pauseMenuUI != null)
        {
            Button[] buttons = pauseMenuUI.GetComponentsInChildren<Button>(true);
            foreach (Button button in buttons)
            {
                if (button.gameObject.name.ToLower().Contains("resume"))
                {
                    return button;
                }
            }
        }
        return null;
    }
}
