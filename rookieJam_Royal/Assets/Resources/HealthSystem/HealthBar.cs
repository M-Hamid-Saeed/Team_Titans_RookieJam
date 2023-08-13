using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerHealth playerHealth;
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    private void Update()
    {
       
            float fillValue = playerHealth.GetCurrentHealth() / playerHealth.GetMaxHealth();
            slider.value = fillValue;
        
    }
}
