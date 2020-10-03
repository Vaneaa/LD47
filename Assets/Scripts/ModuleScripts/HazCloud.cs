using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazCloud : Hazard
{
    FrameTimer tick = new FrameTimer(30);
    bool active = true;

    //cloud collide will periodically deal damage
    void cloudCollide()
    {
        if(active == true)
        {
            //cloud damage
            active = false;
        }
        else if(tick.go())
        {
            active = true;
        }
    }

    void Start()
    {
        init();
        collideBase = new onCollide(cloudCollide);
        collideSAL = new onCollide(cloudCollide);
        collideSAR = new onCollide(cloudCollide);
    }
    void Update()
    {
        run();
    }
}
