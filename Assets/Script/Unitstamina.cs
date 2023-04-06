using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript
{
//Fields

        float _currentStamina;
        float _currentMaxStamina;
        float _staminaRegenSpeed;
    bool _pauseStaminaRegen = false;


        //Properties

        public float Stamina
    {
        get
        {
            return _currentStamina;
        }
        set
        {
            _currentHealth = value;
        }
    }

    public int MaxStamina
    {
        get
        {
            return _currentMaxStamina;
        }
        set
        {
            _currentMaxStamina = value;
        }
    }

    public float StaminaRegenSpeed
    {
        get
        {
            return _staminaRegenSpeed;
        }
        set
        {
            _staminaRegenSpeed = value;
        }
    }

    public int PauseStamina
    {
        get
        {
            return _currentMaxStamina;
        }
        set
        {
            _currentMaxStamina = value;
        }
    }
    // Constructor

    public unitHealth(int health, int maxHealth)
    {
        _currentHealth = health;
        _currentMaxHealth = maxHealth;
    }

    //Methods

    public void DmgUnit(int dmgAmount)
    {
        if (_currentHealth > 0)
        {
            _currentHealth -= dmgAmount;
        }
    }

    public void HealUnit(int healAmount)
    {
        if (_currentHealth < _currentMaxHealth)
        {
            _currentHealth += healAmount;
        }
        if (currentHealth > _currentMaxHealth)
        {
            _currentHealth = _currentMaxHealth;
        }
    }
}
