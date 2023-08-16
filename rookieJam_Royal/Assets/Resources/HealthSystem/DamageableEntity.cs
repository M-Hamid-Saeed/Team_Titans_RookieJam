using System.Collections;
using UnityEngine;

public class DamageableEntity : MonoBehaviour, IDamageable
{
    public float maxHealth = 100f;
    protected float currentHealth;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Debug.Log("TAKING DAMAGE");
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

    public virtual void Die()
    {
        // Implement death logic here
        ObjectPooler.Instance?.Free(this.gameObject);
        PlayParticles();
    }
    private void PlayParticles()
    {
        GameObject particle = ObjectPooler.Instance?.SpawnFromPool("EnemyDeath", this.transform.position, Quaternion.identity);

        WaitForParticlePlay(particle);
    }
    IEnumerator WaitForParticlePlay(GameObject particle)
    {
        yield return new WaitForSeconds(.01f);
        ObjectPooler.Instance?.Free(particle);

    }
}
