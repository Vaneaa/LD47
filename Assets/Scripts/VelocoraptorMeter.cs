using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocoraptorMeter : MonoBehaviour
{
    UnityEngine.UI.Text display;
    Spaceship plr;
    // Start is called before the first frame update
    void Start()
    {
        plr = GameObject.Find("Spaceship").GetComponent<Spaceship>();
        display = GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        display.text = plr.spaceshipHorizontalSpeed.ToString();
    }
}
