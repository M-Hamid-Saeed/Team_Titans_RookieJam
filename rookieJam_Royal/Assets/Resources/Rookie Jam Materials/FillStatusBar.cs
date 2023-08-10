using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillStatusBar : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Image fillImage;
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {

        float fillValue = playerHealth.currentHealth / playerHealth.maxHealth;
        Debug.Log("Updating health bar. Fill Value: " + fillValue);

        slider.value = fillValue;
    }
}
