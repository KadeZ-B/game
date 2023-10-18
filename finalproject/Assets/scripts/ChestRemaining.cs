using UnityEngine;
using UnityEngine.UI;

public class ChestCounter : MonoBehaviour
{
    public Text chestCountText; // Assign the Text component from the Inspector.
    public ChestManager chestManager; // Assign the ChestManager from the Inspector.

    // Update is called once per frame
    void Update()
    {
        // Check if the chestManager reference is set.
        if (chestManager != null)
        {
            // Get the count of remaining chests from the ChestManager.
            int remainingChests = chestManager.remainingChests;

            // Update the text to display the remaining chest count.
            chestCountText.text = "Remaining Chests: " + remainingChests.ToString();
        }
        else
        {
            // Handle the case when the ChestManager reference is not set.
            chestCountText.text = "Remaining Chests: N/A";
        }
    }
}

