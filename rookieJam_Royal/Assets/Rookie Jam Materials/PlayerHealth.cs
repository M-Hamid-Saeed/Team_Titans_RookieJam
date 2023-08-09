using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;  // Maximum health of the player
    public float currentHealth = 100f;     // Current health of the player



    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;  // Decrease current health by the damage amount

        if (currentHealth <= 0)
        {
            Die();  // If health drops to or below zero, the player dies
        }
    }

    private void Die()
    {
        // Handle player's death here (e.g., game over, respawn, etc.)
        // For now, let's just deactivate the player GameObject
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.StartsWith("Enemy"))
        {
            TakeDamage(10f);  // Example: If an enemy enters the tower, the player takes damage
        }
    }

}
