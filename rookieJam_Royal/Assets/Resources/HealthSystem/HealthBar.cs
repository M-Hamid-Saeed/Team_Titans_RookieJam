using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerHealth playerHealth;
    private Slider slider;
    public GameController gameController;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    private void Update()
    {
       
            float fillValue = playerHealth.GetCurrentHealth() / playerHealth.GetMaxHealth();
            slider.value = fillValue;


        if (fillValue <= 0) // Check if health reaches zero
        {
            playerHealth.ResetHealth();
            gameController.PlayAgain();
        }
    }
}
