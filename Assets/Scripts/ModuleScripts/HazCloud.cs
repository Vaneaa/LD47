using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazCloud : Hazard
{
    FrameTimer tick = new FrameTimer(30);
    bool active = true;

    void cloudCollide()
    {

    }

    //cloud collide will periodically deal damage
    void cloudCollideSAL()
    {
        //if (plr.GetComponent<Spaceship>().shieldActive == false) plr.GetComponent<Spaceship>().HP -= 15;
        //else plr.GetComponent<Spaceship>().energy -= hp + shieldDamageMod;
        if (active == true)
        {
            //cloud damage
            if (plr.GetComponent<Spaceship>().shieldActive == false) plr.GetComponent<Spaceship>().leftSolarHP -= 1;
            else plr.GetComponent<Spaceship>().energy -= hp + shieldDamageMod;
            active = false;
        }
        else if(tick.go())
        {
            active = true;
        }
    }

    void cloudCollideSAR()
    {
        if (active == true)
        {
            //cloud damage
            if (plr.GetComponent<Spaceship>().shieldActive == false) plr.GetComponent<Spaceship>().rightSolarHP -= 1;
            else plr.GetComponent<Spaceship>().energy -= hp + shieldDamageMod;
            active = false;
        }
        else if (tick.go())
        {
            active = true;
        }
    }

    void cloudProjCollide()
    {

    }

    void Start()
    {
        init();
        collideBase = new onCollide(cloudCollide);
        collideSAL = new onCollide(cloudCollideSAL);
        collideSAR = new onCollide(cloudCollideSAR);
        collideLazer = new onCollide(cloudProjCollide);
        collideCannon = new onCollide(cloudProjCollide);
        canStopProjectiles = false;
    }
    void Update()
    {
        run();
    }
}
