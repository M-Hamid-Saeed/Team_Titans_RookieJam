using UnityEngine;

public class PlayerHealth : DamageableEntity
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.StartsWith("Enemy"))
        {
            TakeDamage(10f);  // Example: If an enemy enters the player's trigger zone, the player takes damage
        }
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }

}

