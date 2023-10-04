using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public new string itemName;
    public Sprite icon;
    public int goldAmount; // Add a property to represent the gold amount.
}

public class ChestController : MonoBehaviour
{
    // The items that can be found in the chest.
    public Item[] items;

    // The gold that can be found in the chest.
    public int goldAmount = 100; // Set your desired gold amount here.

    // Reference to the closed chest model.
    private GameObject closedChest;

    // Reference to the open chest model.
    public GameObject openChest;

    // Flag to track whether the chest is open.
    private bool isOpen = false;

    private void Start()
    {
        // Initialize references.
        closedChest = transform.Find("ClosedChest").gameObject;
        openChest.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (!isOpen)
        {
            // Chest is closed, open it and distribute items and gold.
            isOpen = true;
            closedChest.SetActive(false);
            openChest.SetActive(true);

            // Handle item and gold distribution here.
            DistributeItems();
            DistributeGold();
        }
    }

    // Function to distribute items to the player's inventory.
    private void DistributeItems()
    {
        foreach (Item item in items)
        {
            // You can implement the logic to add items to the player's inventory here.
            // For example, you can use a GameManager or InventoryManager script.
            // item can have information like name, icon, stats, etc.
            // GameManager.Instance.AddItemToInventory(item);
            Debug.Log("You found " + item.itemName + "!");
        }
    }

    // Function to distribute gold to the player's inventory.
    private void DistributeGold()
    {
        // You can implement the logic to add gold to the player's inventory here.
        // For example, you can use a GameManager or InventoryManager script.
        // GameManager.Instance.AddGold(goldAmount);
        Debug.Log("You found " + goldAmount + " gold!");
    }
}
