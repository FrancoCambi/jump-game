using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider mySlider;
    public Gradient gradient;
    public Image fill;
    
    private void Start()
    {
        mySlider = GetComponent<Slider>();
    }


    public void SetMaxHealth(int maxHealth)
    {
        mySlider.maxValue = maxHealth;
        mySlider.value = maxHealth;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        mySlider.value = health;

        fill.color = gradient.Evaluate(mySlider.normalizedValue);
    }
}
