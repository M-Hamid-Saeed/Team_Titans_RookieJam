using UnityEngine;

public class DamageableEntity : MonoBehaviour, IDamageable
{
    public float maxHealth = 100f;
    protected float currentHealth;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    protected virtual void Die()
    {
        // Implement death logic here
        gameObject.SetActive(false);
    }
}
