using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    public Slider slider;
    //public Gradient gradient;
    public Image fill;
    float vl2;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
       // fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(int health)
    {
        slider.value = health;
        vl2 = slider.value/slider.maxValue;
        fill.fillAmount = vl2;
       // fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
