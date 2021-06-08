using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainGenerator : MonoBehaviour {
    [SerializeField] Material rainMaterial;
    DayNightSystem2D environment;
    public enum DayCycles{
        Sunrise = 0,
        Day = 1,
        Sunset = 2,
        Night = 3,
        Midnight = 4
    }
    void Start(){
        environment = GameObject.FindObjectOfType<DayNightSystem2D>();
    }
    void Update() {
        if(environment.dayCycle == global::DayCycles.Sunrise && environment.cycleCurrentTime > 60){
            rainMaterial.color = new Color(115f/255f, 174/255f, 236/255f);
        }else{
            rainMaterial.color = new Color(44/255f, 80/255f, 118/255f);
        }
    }
}
