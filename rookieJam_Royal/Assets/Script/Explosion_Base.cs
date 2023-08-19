
using System.Collections;
using UnityEngine;

//This class is base class for all explosives

public class Explosion_Base : MonoBehaviour, IDamageable
{

    [SerializeField] protected float MaxHealth;
    [SerializeField] protected float MaxDamageTaken;
    [SerializeField] protected float ExplosionDamage;
    [Space(3)]
    [SerializeField] GameObject explosionRange;
    [Space(3)]
    [SerializeField] GameObject ExplosionParticle;
    //[SerializeField]  SoundType ExplosionSound;
    [SerializeField] protected float volume;
    [SerializeField] protected CameraShake_Management CameraShaker;
  
    public float currentHealth;

    private void Awake()
    {

        currentHealth = MaxHealth;
        explosionRange.SetActive(false);

    }
    public void TakeDamage(float damage)
    {
        
        if (damage <= MaxDamageTaken)
            currentHealth -= damage;
        else
            currentHealth -= MaxDamageTaken;

        if (currentHealth <= 0)
        {
            /* Disabling mesh at on explosive health = 0, but destroying object after
             sometime to make the explosion damage in explosion range*/
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
            PlayParticle_Sound();
            Debug.Log("IN THE DAMAGE");
            if (explosionRange)
                explosionRange.SetActive(true);
            StartCoroutine(WaitForDestroy());

            /*Disabling drumexplosive visual collider as the gameobject will destroy 
            after some time so even after meshrenderer off, the collider can still get the bullet damage
            creating multiple explosion effects*/
            //Box collider in only on drumexplosive visual, should not disable the missle visual collider
            BoxCollider drumExplosiveCollider = gameObject.GetComponentInChildren<BoxCollider>();
            CapsuleCollider MissleCollider = gameObject.GetComponentInChildren<CapsuleCollider>();
            if (drumExplosiveCollider)
                drumExplosiveCollider.enabled = false;
            if (MissleCollider)
                MissleCollider.enabled = false;
           
        }

    }


    private IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(.1f);
        CameraShaker.ShakeCamera();
        Destroy(gameObject);
    }
    private void PlayExplosionParticle()
    {
        // ParticleManager.Instance?.PlayParticle(ExplosinParticleType, new Vector3(transform.position.x,transform.position.y+1f,transform.position.z));
        //SoundManager.Instance.PlayOneShot(ExplosionSound,1f);
    }



    public void PlayParticle_Sound()
    {
        FindObjectOfType<AudioManager>().Play("explosion");
        GameObject particle = Instantiate(ExplosionParticle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
       
        Destroy(particle, 1f);
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public float GetMaxHealth()
    {
        return MaxHealth;
    }
}

