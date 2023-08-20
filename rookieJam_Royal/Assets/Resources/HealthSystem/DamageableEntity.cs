using DG.Tweening;
using System.Collections;
using UnityEngine;

public class DamageableEntity : MonoBehaviour, IDamageable
{
    public float maxHealth = 100f;
    protected float currentHealth;
    [SerializeField]
    protected CameraShake_Management CameraShaker;
    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        transform.DOShakeRotation(1f, 20, 10, 50,true);
        //transform.DOScale(.5f, .2f);
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
       
        
        CameraShaker.ShakeCamera();
        EnemySpawner.AddKillCount();
        PlayParticles();
    }
    private void PlayParticles()
    {
        GameObject particle = ObjectPooler.Instance?.SpawnFromPool("EnemyDeath", this.transform.position, Quaternion.identity);

        StartCoroutine(WaitForParticlePlayAndFree(particle));
    }

    private IEnumerator WaitForParticlePlayAndFree(GameObject particle)
    {
        // Assuming your particle system component is named "ParticleSystem"
        ParticleSystem particleSystem = particle.GetComponent<ParticleSystem>();
        particleSystem.Play();
        yield return new WaitForSeconds(particleSystem.main.duration);
        ObjectPooler.Instance?.Free(particle);
        ObjectPooler.Instance?.Free(this.gameObject);
    }

}
