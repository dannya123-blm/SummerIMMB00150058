using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar; // Reference to the health bar UI
    public AudioClip deathAudioClip;
    private AudioSource audioSource;
    public bool hasTemporaryShield = false; // Add temporary shield state
    public GameObject shield;
    public int shieldHits = 3;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        audioSource = GetComponent<AudioSource>();
        if (shield != null)
        {
            shield.SetActive(false); // Ensure the shield is initially inactive
        }
    }

    public void TakeDamage(int damage)
    {
        if (hasTemporaryShield)
        {
            // If the player has a temporary shield, the shield absorbs the damage
            shieldHits--; // Decrement the shield hit counter
            Debug.Log("Shield absorbed the damage! Remaining hits: " + shieldHits);

            if (shieldHits <= 0)
            {
                hasTemporaryShield = false; // Shield is used up
                if (shield != null)
                {
                    shield.SetActive(false); // Hide the shield
                }
                Debug.Log("Shield is depleted!");
            }
        }
        else
        {
            // If no shield, the player takes damage
            currentHealth -= damage;
            if (currentHealth < 0)
                currentHealth = 0;

            healthBar.SetHealth(currentHealth, maxHealth); // Ensure correct parameters are passed

            if (currentHealth == 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        audioSource.PlayOneShot(deathAudioClip);
        StartCoroutine(WaitAndLoadGameOverScene());
    }

    IEnumerator WaitAndLoadGameOverScene()
    {
        yield return new WaitForSeconds(deathAudioClip.length + 2f);
        SceneManager.LoadScene("GameOver");
    }

    // Method to activate the temporary shield power-up
    public void ActivateTemporaryShield(float duration)
    {
        StartCoroutine(TemporaryShieldCoroutine(duration));
    }

    private IEnumerator TemporaryShieldCoroutine(float duration)
    {
        hasTemporaryShield = true;
        shieldHits = 3; // Reset the shield hit counter to 3
        if (shield != null)
        {
            shield.SetActive(true); // Show the shield
        }
        Debug.Log("Temporary shield activated with " + shieldHits + " hits!");

        yield return new WaitForSeconds(duration);

        hasTemporaryShield = false;
        if (shield != null)
        {
            shield.SetActive(false); // Hide the shield
        }
        Debug.Log("Temporary shield is now inactive.");
    }
}
