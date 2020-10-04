using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocoraptorMeter : MonoBehaviour
{
    UnityEngine.UI.Text display;
    UnityEngine.UI.Text fuelDisplay;
    UnityEngine.UI.Text energyDisplay;
    Spaceship plr;


    void Start()
    {
        plr = GameObject.Find("Spaceship").GetComponent<Spaceship>();
        display = GetComponent<UnityEngine.UI.Text>();
        fuelDisplay = GameObject.Find("Fuel").GetComponent<UnityEngine.UI.Text>();
        energyDisplay = GameObject.Find("Energy").GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        display.text = plr.spaceshipHorizontalSpeed.ToString();
        fuelDisplay.text = plr.fuel.ToString();
        energyDisplay.text = plr.energy.ToString();
    }
}
