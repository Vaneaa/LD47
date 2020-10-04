using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    FrameTimer animationSpeed = new FrameTimer(10);
    public int animSpeed = 10;
    public Sprite[] sprites;
    public int currentFrame = 0;
    public int lastFrame;
    public int firstFrame = 0;
    public bool pause = false;
    public bool playForward = true;
    SpriteAnimator(int animationDelay, Sprite[] spritesheet)
    {
        //animationSpeed = new FrameTimer(10);
        animSpeed = animationDelay;
        sprites = spritesheet;
    }

    public void resetAnimation()
    {
        currentFrame = 0;
    }

    private void Start()
    {
        animationSpeed = new FrameTimer(animSpeed);
    }
    void Update()
    {
        //update settings
        animationSpeed.duration = animSpeed;
        lastFrame = sprites.Length - 1;
        firstFrame = 0;

        //animate
        if(animationSpeed.go())
        {
            
            GetComponent<SpriteRenderer>().sprite = sprites[currentFrame];

            //play forward
            if(playForward && pause == false)
            {
                if (currentFrame < sprites.Length - 1) currentFrame += 1;
                else currentFrame = 0;
            }
            //play backwards
            else if(pause == false)
            {
                if (currentFrame > 0) currentFrame -= 1;
                else currentFrame = sprites.Length - 1;
            }


        }
    }
}
