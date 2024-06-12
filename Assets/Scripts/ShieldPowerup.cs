using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public float shieldDuration = 5f; // Duration of the shield in seconds

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Get the PlayerHealth component from the player
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // Activate the shield on the player
                playerHealth.ActivateTemporaryShield(shieldDuration);
            }

            // Destroy the shield power-up object
            Destroy(gameObject);
        }
    }
}
