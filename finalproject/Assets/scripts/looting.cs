using UnityEngine;

public class ChestController : MonoBehaviour
{
    public bool isInRange = false;
    private bool isOpen = false;
    private ChestManager chestManager; // Reference to the ChestManager.

    public float interactionRadius = 2.0f; // Radius for interaction with the player.
    public string playerTag = "Player"; // The tag of the player GameObject.

    private void Start()
    {
        chestManager = GameObject.FindObjectOfType<ChestManager>();
    }

    private void Update()
    {
        // Check if the player is in range.
        isInRange = IsPlayerInRange();

        // Handle interaction if the player is in range and clicks.
        if (isInRange && Input.GetMouseButtonDown(0) && !isOpen)
        {
            OpenChest();
        }
    }

    private bool IsPlayerInRange()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactionRadius);

        foreach (var collider in colliders)
        {
            if (collider.CompareTag(playerTag))
            {
                return true;
            }
        }

        return false;
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
