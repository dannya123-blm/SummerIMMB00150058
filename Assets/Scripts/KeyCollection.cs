using UnityEngine;

public class KeyCollect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // This updates the players key count
            Inventory playerInventory = other.GetComponent<Inventory>();
            if (playerInventory != null)
            {
                playerInventory.CollectKey();
            }

            // Destroy the key object after collection
            Destroy(gameObject);
        }
    }
}
