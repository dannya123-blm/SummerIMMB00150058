using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

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
        audioSource.PlayOneShot(deathAudioClip);

        // Start the coroutine to wait and then load the GameOver scene
        StartCoroutine(WaitAndLoadGameOverScene());
    }
    IEnumerator WaitAndLoadGameOverScene()
    {
        // Wait for the length of the death audio clip
        yield return new WaitForSeconds(deathAudioClip.length + 2f); 

        // Load the GameOver scene
        SceneManager.LoadScene("GameOver");
    }
}
