using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VelocoraptorMeter : MonoBehaviour
{
    UnityEngine.UI.Text display;
    UnityEngine.UI.Text fuelDisplay;
    UnityEngine.UI.Text energyDisplay;
    UnityEngine.UI.Text ammoDisplay;
    UnityEngine.UI.Text hpDisplay;
    Spaceship plr;


    void Start()
    {
        plr = GameObject.Find("Spaceship").GetComponent<Spaceship>();
        display = GetComponent<UnityEngine.UI.Text>();
        fuelDisplay = GameObject.Find("Fuel").GetComponent<UnityEngine.UI.Text>();
        energyDisplay = GameObject.Find("Energy").GetComponent<UnityEngine.UI.Text>();
        ammoDisplay = GameObject.Find("Ammo").GetComponent<UnityEngine.UI.Text>();
        hpDisplay = GameObject.Find("HP").GetComponent<UnityEngine.UI.Text>();

    }

    // Update is called once per frame
    void Update()
    {
        display.text = plr.spaceshipHorizontalSpeed.ToString();
        fuelDisplay.text = Mathf.Floor(plr.fuel).ToString();
        energyDisplay.text = Mathf.Floor(plr.energy).ToString() + "(+" + plr.solarEfficiency.ToString() + ")";
        ammoDisplay.text = plr.ammo.ToString();
        hpDisplay.text = plr.HP.ToString();
    }
}
