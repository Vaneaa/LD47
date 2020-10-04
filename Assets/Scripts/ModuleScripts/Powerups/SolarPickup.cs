﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarPickup : Hazard
{
    void pickup()
    {
        plr.GetComponent<Spaceship>().leftSolarHP = 100;
        plr.GetComponent<Spaceship>().rightSolarHP = 100;
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
