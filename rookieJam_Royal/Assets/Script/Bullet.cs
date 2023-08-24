using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;  // Reference to the Rigidbody component
    public float speed = 10.0f;
    private Vector3 direction;
    private TrailRenderer trailRenderer;
    private float damage;
    private Vector3 hitPos;
    private float lifeTime = 2;
    GameObject particle;
    [SerializeField] BulletPooler bulletPooler;
   
    [SerializeField] SoldierPooler soldierPooler;
    private Transform bulletSpawnPoint;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        trailRenderer = GetComponentInChildren<TrailRenderer>();
    }

    public void SetDirection(Vector3 direction)
    {
        EnableTrail(true);
        if (rb)
            rb.velocity = Vector3.zero;
        
        this.direction = direction;
    }

    void FixedUpdate()
    {

        rb.velocity = direction.normalized * (speed * Time.fixedDeltaTime);
        transform.rotation = Quaternion.LookRotation(direction.normalized, Vector3.up);
        lifeTime -= Time.fixedDeltaTime;
        if (lifeTime < 0)
        {
            //Debug.Log("Bullet Freed");

            bulletPooler.ReturnToPool(this.gameObject);
            EnableTrail(false);
            lifeTime = 2;
            ObjectPooler.Instance?.Free(particle);
        }
    }
   

    public void SetDamage(int damage)
    {
        this.damage = damage;
        Debug.Log(this.damage);

    }
    public void SetHitPosition(Vector3 pos)
    {
       hitPos = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
      /*  if (hasCollided) // Already processed collision, ignore
            return;

        hasCollided = true; // Mark as collided*/

        IDamageable damageableEntity = collision.gameObject.GetComponent<IDamageable>();
        if (damageableEntity != null)
        {
            damageableEntity.TakeDamage(damage);
            particle = ObjectPooler.Instance?.SpawnFromPool("BulletHit", collision.GetContact(0).point, Quaternion.identity);
            Vibration.VibrateNope();
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            soldierPooler.ReturnToPool(bulletSpawnPoint.gameObject);
        }

        bulletPooler.ReturnToPool(this.gameObject);
        
        EnableTrail(false);
    }

    private void EnableTrail(bool state)
    {
        if (trailRenderer)
        {
            trailRenderer.Clear();
            trailRenderer.enabled = state;
        }
    }
    public void SpawnPoint(Transform pos)
    {
        Debug.Log(pos.gameObject
            );
        bulletSpawnPoint = pos;
    }
}


