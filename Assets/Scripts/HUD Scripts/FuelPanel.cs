using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelPanel : MonoBehaviour
{
    private Spaceship player;
    private Slider fuel;
    // Start is called before the first frame update
    void Start()
    {
        fuel= GameObject.Find("Fuel Panel").GetComponent<Slider>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Spaceship>();
        
    }

    // Update is called once per frame
    void Update()
    {
        fuel.value = player.fuel/100;
    }
}
