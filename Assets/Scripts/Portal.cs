using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory inventory = other.GetComponent<Inventory>();
            if (inventory != null && inventory.keysCollected >= inventory.totalKeys)
            {
                // Load the next level or perform the desired action
                SceneManager.LoadScene("Level_2");
            }
            else
            {
                Debug.Log("Not all keys collected!");
            }
        }
    }
}
