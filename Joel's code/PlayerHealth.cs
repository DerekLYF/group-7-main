using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
        public int maxHealth = 100;
        public int currentHealth;
        public HealthBar healthBar;
        public Canvas deathScreenCanvas;
        public Button restartButton;

        void Start()
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        void Die()
        {
        deathScreenCanvas.enabled = true;

        // Optional: Add this line if you added a restart button
        restartButton.onClick.AddListener(RestartGame);
        }

        void RestartGame()
        {
        // Replace "YourSceneName" with the name of your current scene
        SceneManager.LoadScene("YourSceneName");
        }
}
