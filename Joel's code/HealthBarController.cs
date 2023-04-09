using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//input this code into the healthbar
public class HealthBar : MonoBehaviour
{
    public Image healthBarFill;
    public float currentHealth = 100f;
    public float maxHealth = 100f;

    public void SetHealth(float newHealth)
    {
        currentHealth = Mathf.Clamp(newHealth, 0, maxHealth);
        float healthPercentage = currentHealth / maxHealth;
        healthBarFill.fillAmount = healthPercentage;
    }
    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
