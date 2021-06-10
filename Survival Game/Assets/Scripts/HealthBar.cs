using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour {
    public Slider slider;
    [SerializeField] Gradient gradient;
    [SerializeField] Image fill;
    public void setSliderValue(float value){
        slider.value = value;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
