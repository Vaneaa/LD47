using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarPickup : Hazard
{
    public GameObject sfxObj;
    void pickup()
    {
        plr.GetComponent<Spaceship>().leftSolarHP = 100;
        plr.GetComponent<Spaceship>().rightSolarHP = 100;
        Instantiate(sfxObj, transform.position, Quaternion.identity);
        Explode();
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
        canStopProjectiles = false;
    }

    // Update is called once per frame
    void Update()
    {
        run();
    }
}
