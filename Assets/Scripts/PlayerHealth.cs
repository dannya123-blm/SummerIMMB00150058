using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public AudioClip deathAudioClip;  
    private AudioSource audioSource;  

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        audioSource = GetComponent<AudioSource>();  
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
            currentHealth = 0;

        healthBar.SetHealth(currentHealth, maxHealth);

        if (currentHealth == 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("The player has died");
        audioSource.PlayOneShot(deathAudioClip);  // Play the death audio clip
    }
}
