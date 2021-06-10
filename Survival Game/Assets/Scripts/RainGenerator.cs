using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainGenerator : MonoBehaviour {
    [SerializeField] Material rainMaterial;
    [SerializeField] float rainChance = 50f;
    [SerializeField] ParticleSystem rain;
    DayNightSystem2D environment;
    [SerializeField] bool raining;
    [SerializeField] float timeToRain;
    public enum DayCycles{
        Sunrise = 0,
        Day = 1,
        Sunset = 2,
        Night = 3,
        Midnight = 4
    }
    void Start(){
        environment = GameObject.FindObjectOfType<DayNightSystem2D>();
        raining = false;
    }
    void Update() {
        if((environment.dayCycle == global::DayCycles.Sunrise && environment.cycleCurrentTime > 60) || (environment.dayCycle == global::DayCycles.Day && environment.cycleCurrentTime < 200)){
            rainMaterial.color = new Color(115f/255f, 174/255f, 236/255f);
        }else{
            rainMaterial.color = new Color(44/255f, 80/255f, 118/255f);
        }
        if(timeToRain > 0){
            timeToRain -= Time.deltaTime;
            if(timeToRain <= 0){
                toggleRain(0f);
                timeToRain = 0;
            }
        }
    }
    private void toggleRain(float rainEmission){
        var em = rain.emission;
        em.rateOverTime = rainEmission;
        timeToRain = Random.Range(240, 480);
    }
    public void rainCheck(){
        if(Random.Range(0, 100) < rainChance && !raining){
            toggleRain(30f);
        }
    }
}
