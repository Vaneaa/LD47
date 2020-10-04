using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPickup : Hazard
{
    bool collected = false;
    void pickup()
    {
        if (!collected)
        {
            plr.GetComponent<Spaceship>().fuel += 3f;
            collected = true;
        }
    }
    void doNothing()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        init();
        collideBase = pickup;
        collideSAL = pickup;
        collideSAR = pickup;
        collideShield = pickup;
        collideLazer = doNothing;
        collideCannon = doNothing;
    }

    // Update is called once per frame
    void Update()
    {
        run();
    }
}
