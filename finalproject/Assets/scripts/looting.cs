using UnityEngine;

public class ChestController : MonoBehaviour
{
    private bool isOpen = false;
    private ChestManager chestManager; // Reference to the ChestManager.

    private void Start()
    {
        chestManager = GameObject.FindObjectOfType<ChestManager>();
    }

    private void OnMouseDown()
    {
        if (!isOpen)
        {
            OpenChest();
        }
    }

    private void OpenChest()
    {
        int goldReward = UnityEngine.Random.Range(10, 101); // Generate a random number between 10 and 100.

        // You can do something with the gold, such as adding it to the player's inventory.
        // Display the gold amount in the debug log.
        DisplayGoldAmount(goldReward);

        // Notify the ChestManager that this chest is removed.
        if (chestManager != null)
        {
            chestManager.ChestRemoved();
        }

        // Destroy the chest GameObject to make it disappear:
        Destroy(gameObject);

        isOpen = true;
    }

    private void DisplayGoldAmount(int goldReward)
    {
        Debug.Log("You found " + goldReward + " gold!");
    }
}
