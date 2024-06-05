using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damageAmount = 10;  
    public bool destroyOnCollision = false;  // Whether the enemy should be destroyed upon collision
    public float moveSpeed = 3f;  
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // Move towards the player
        if (playerTransform != null)
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the PlayerHealth component from the player
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // Inflict damage to the player
                playerHealth.TakeDamage(damageAmount);

                // Destroy the enemy if needed
                if (destroyOnCollision)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
