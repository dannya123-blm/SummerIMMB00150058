using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    private Inventory inventory;

    void Start()
    {
        // Find the Inventory component on the player
        inventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
    }

    // Called when the player collides with another collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player collides with a key
        if (other.CompareTag("Key"))
        {
            // Destroy the key GameObject
            Destroy(other.gameObject);

            // Increment the keys collected counter in the Inventory
            if (inventory != null)
            {
                inventory.CollectKey();
            }

            Debug.Log("Key collected! Total keys collected: " + inventory.keysCollected);
        }
    }
}
