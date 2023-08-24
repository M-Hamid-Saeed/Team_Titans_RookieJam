using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public LevelManager levelManager;

    private void Start()
    {
        currentHealth = 100;
    }
    public  void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Debug.Log("TAKING DAMAGE");
            Death();
        }
    }

    public void Death()
    {
        
        levelManager.ReloadSceneWithEnvironmentsSwitched();
        levelManager.SwitchEnvironments(); ;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.StartsWith("Enemy"))
        {
            TakeDamage(5f);  // Example: If an enemy enters the player's trigger zone, the player takes damage
        }
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

}

