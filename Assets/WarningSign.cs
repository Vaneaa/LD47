using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningSign : MonoBehaviour
{
    private Spaceship player;
    private Image WarningPanel;
    private Image FuelLow;
    private Image EnergyLow;
    private Image VelocityLow;
    private Image VelocityHigh;
    private Image SolarDamageSign;
    // Start is called before the first frame update
    void Start()
    {
        WarningPanel = GameObject.Find("WarningPanel").GetComponent<Image>();
        FuelLow = GameObject.Find("FuelLow").GetComponent<Image>();
        EnergyLow = GameObject.Find("EnergyLow").GetComponent<Image>();
        VelocityLow = GameObject.Find("VelocityLow").GetComponent<Image>();
        VelocityHigh = GameObject.Find("VelocityHigh").GetComponent<Image>();
        SolarDamageSign = GameObject.Find("SolarDamageSign").GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Spaceship>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.danger){
            WarningPanel.enabled = true;
        }else{
            WarningPanel.enabled = false;
        }
        if(player.fuel < 20){
            FuelLow.enabled = true;
        }else{
            FuelLow.enabled = false;
        }
        if(player.energy < 20){
            EnergyLow.enabled = true;
        }else{
            EnergyLow.enabled = false;
        }
        if(player.spaceshipHorizontalSpeed < 0.8f){
            VelocityLow.enabled = true;
        }else{
            VelocityLow.enabled = false;
        }
        if(player.spaceshipHorizontalSpeed > 10){
            VelocityHigh.enabled = true;
        }else{
            VelocityHigh.enabled = false;
        }
        if(player.solarEfficiency < 1){
            SolarDamageSign.enabled = true;
        }else{
            SolarDamageSign.enabled = false;
        }
        
    }
}
