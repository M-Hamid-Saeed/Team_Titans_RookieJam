using DG.Tweening;
using System.Collections;
using UnityEngine;

public class DamageableEntity : MonoBehaviour, IDamageable
{
    public float maxHealth = 100f;
    protected float currentHealth;
    [SerializeField]
    protected CameraShake_Management CameraShaker;
   // [SerializeField] EnemySpawner enemySpawner;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        transform.DOShakeRotation(1f, 20, 10, 50);
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

    public void Die()
    {
        this.GetComponent<BoxCollider>().enabled = false;
        CameraShaker.ShakeCamera();
        EnemySpawner.AddKillCount();
        PlayParticles();
    }
    private void PlayParticles()
    {
        GameObject particle = ObjectPooler.Instance?.SpawnFromPool("EnemyDeath", new Vector3(transform.position.x, transform.position.y + 1f,transform.position.z), Quaternion.identity); ;
        StartCoroutine(WaitForParticlePlayAndFree(particle));
        
    }

    private IEnumerator WaitForParticlePlayAndFree(GameObject particle)
    {
        // Assuming your particle system component is named "ParticleSystem"
        ParticleSystem particleSystem = particle.GetComponent<ParticleSystem>();
        particleSystem.Play();
        yield return new WaitForSeconds(0.3f);
        ObjectPooler.Instance?.Free(particle);
        ObjectPooler.Instance?.Free(this.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            Die();
        }
    }
}
