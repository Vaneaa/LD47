using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPowerup : Hazard
{
    bool collected = false;
    public GameObject sfxObj;
    void pickup()
    {
        if (!collected)
        {
            plr.GetComponent<Spaceship>().ammo += 1;
            Instantiate(sfxObj, transform.position, Quaternion.identity);
            collected = true;
        }
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
