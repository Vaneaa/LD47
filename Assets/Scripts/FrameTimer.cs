using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameTimer{

    public int animationTimer = 0;
    public int duration = 0;
    public FrameTimer(int frameCount)
    {
        duration = frameCount;
    }
    public bool go()
    {
        animationTimer += 1;
        if(animationTimer >= duration)
        {
            animationTimer = 0;
            return true;
        }
        else
        {
            return false;
        }
    }
}
