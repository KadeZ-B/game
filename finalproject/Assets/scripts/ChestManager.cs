using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChestManager : MonoBehaviour
{
    public int totalChests = 0; // Set this in the Inspector to the total number of chests in your scene.
    public string gameOverSceneName = "GameOver"; // Name of the game over scene.

    public int remainingChests; // Make this variable public.
    private float timer;
    public float timeLimitSeconds = 300f; // Set the time limit in seconds.
    public Text chestCount; // Reference to the UI Text component.
    public Text timerText; // Reference to the UI Text component for displaying the timer.

    void Start()
    {
        remainingChests = totalChests;
        timer = timeLimitSeconds;

        // Update the UI to display the initial count of chests and the timer.
        UpdateUI();
    }

    void Update()
    {
        // Update the timer and check if time has run out.
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            // Time's up, switch to the game over scene.
            SwitchToGameOverScene();
        }

        // Update the UI to reflect the new remaining count and timer.
        UpdateUI();
    }

    // Method to call when a chest is removed.
    public void ChestRemoved()
    {
        remainingChests--;

        if (remainingChests <= 0)
        {
            // All chests are removed, switch to the game over scene.
            SwitchToGameOverScene();
        }

        // Update the UI to reflect the new remaining count.
        UpdateUI();
    }

    // Update the UI element to display the remaining chests count and timer.
    void UpdateUI()
    {
        if (chestCount != null)
        {
            chestCount.text = "Remaining Chests: " + remainingChests;
        }

        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.Ceil(timer).ToString();
        }
    }

    void SwitchToGameOverScene()
    {
        SceneManager.LoadScene(gameOverSceneName);
    }
}
