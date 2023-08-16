using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;  // Reference to the Rigidbody component
    public float speed = 10.0f;
    private Vector3 direction;
    private float damage;
    private Vector3 hitPos;
    private float lifeTime = 2;
    [SerializeField] BulletPooler bulletPooler;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void SetDirection(Vector3 direction)
    {
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
            lifeTime = 5;
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
        IDamageable damageableEntity = collision.gameObject.GetComponent<IDamageable>();
        if (damageableEntity != null)
        {
            damageableEntity.TakeDamage(damage);
        }

        bulletPooler.ReturnToPool(this.gameObject);
    }
}


