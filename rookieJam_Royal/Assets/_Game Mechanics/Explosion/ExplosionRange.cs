using UnityEngine;

public class ExplosionRange : MonoBehaviour
{
    private void Start()
    {
        Destroy(this.gameObject, .1f);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            DamageableEntity insect_health = other.gameObject.GetComponentInParent<DamageableEntity>();

           if(insect_health)
                insect_health.Die();
            
        }
    }

}

