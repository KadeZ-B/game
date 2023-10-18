using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChestManager : MonoBehaviour
{
    public int totalChests = 0; // Set this in the Inspector to the total number of chests in your scene.
    public string gameOverSceneName = "GameOver"; // Name of the game over scene.

    public int remainingChests; // Make this variable public.

    public Text chestCount; // Reference to the UI Text component.

    void Start()
    {
        remainingChests = totalChests;

        // Update the UI to display the initial count of chests.
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

    // Update the UI element to display the remaining chests count.
    void UpdateUI()
    {
        if (chestCount != null)
        {
            chestCount.text = "Remaining Chests: " + remainingChests;
        }
    }

    void SwitchToGameOverScene()
    {
        SceneManager.LoadScene(gameOverSceneName);
    }
}
