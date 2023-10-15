using UnityEngine;

public class ChestController : MonoBehaviour
{
    private bool isOpen = false;

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
        Debug.Log("You found " + goldReward + " gold!");

        // You can now do something with the gold, such as adding it to the player's inventory.

        // Destroy the chest GameObject to make it disappear:
        Destroy(gameObject);

        isOpen = true;
    }
}
