using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DragonHealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public TMP_Text healthBarText;

    Damageable dragonDamageable;

    private void Awake()
    {
        GameObject dragon = GameObject.FindGameObjectWithTag("dragon");

        if(dragon == null)
        {
            Debug.Log("No dragon found in the scene. Make sure it has tag 'dragon'");
        }

        dragonDamageable = dragon.GetComponent<Damageable>();
    }

    // Start is called before the first frame update
    void Start()
    {
        healthSlider.value = CalculateSliderPercentage(dragonDamageable.Health, dragonDamageable.MaxHealth);
        healthBarText.text = "HP " + dragonDamageable.Health + " / " + dragonDamageable.MaxHealth;
    }

    private void OnEnable()
    {
        dragonDamageable.healthChanged.AddListener(OndragonHealthChanged);
    }

    private void OnDisable()
    {
        dragonDamageable.healthChanged.RemoveListener(OndragonHealthChanged);
    }

    // Calculates with floats so value is returned as a decimal value
    private float CalculateSliderPercentage(float currentHealth, float maxHealth)
    {
        return currentHealth / maxHealth;
    }

    private void OndragonHealthChanged(int newHealth, int maxHealth)
    {
        healthSlider.value = CalculateSliderPercentage(newHealth, maxHealth);
        healthBarText.text = "HP " + newHealth + " / " + maxHealth;
    }   
}
