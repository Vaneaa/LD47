using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    FrameTimer lazerShotDelay = new FrameTimer(10);
    FrameTimer shieldEnergyDrain = new FrameTimer(10);
    FrameTimer cannonShotDelay = new FrameTimer(60);
    public bool cannonReady = true;

    public float spaceshipHorizontalSpeed = 3.0f;
    public static float spaceshipVerticalSpeed = 0;
    public const float MAX_SPEED = 12;
    float speedModifier = 0.005f;

    public float fuel = 100f;
    public float energy = 100f;
    public float HP = 100f;
    public float solarEfficiency;
    public int ammo = 2;

    public float leftSolarHP = 100f;
    public float rightSolarHP = 100f;

    public Lazer lazer;
    GameObject shield;
    GameObject cannon;
    SpriteAnimator shieldAnimator;

    public float shieldEnergyCost = 0.35f;
    public bool shieldActive = false;

    public SpriteRenderer leftSolar;
    public SpriteRenderer rightSolar;
    // Start is called before the first frame update
    void Start()
    {
        lazer = Resources.LoadAll<Lazer>("Lazer")[0];
        shield = GameObject.Find("Shield");
        cannon = Resources.LoadAll<GameObject>("Cannon")[0];
        shieldAnimator = shield.GetComponent<SpriteAnimator>();
        leftSolar = GameObject.Find("SolarArrayL").GetComponent<SpriteRenderer>();
        rightSolar = GameObject.Find("SolarArrayR").GetComponent<SpriteRenderer>();

    }

    void   FixedUpdate()
    {
        //shield energy drain
        if (shieldActive == true && energy > shieldEnergyCost)
        {
            if (shieldEnergyDrain.go()) energy -= shieldEnergyCost;
        }
        else setShieldStatus(false);
        
        
    }

    void setShieldStatus(bool active)
    {
        shieldAnimator.pause = false;
        shieldAnimator.playForward = true;
        shieldActive = active;
        shield.GetComponent<SpriteRenderer>().enabled = active;
        shieldAnimator.currentFrame = shieldAnimator.firstFrame;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 horizontalMove = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        Vector3 verticalMove = new Vector3(0, Input.GetAxis("Vertical"), 0);

        //solar arrays can't fall under 0hp
        if (leftSolarHP <= 0) 
        {
            leftSolarHP = 0;
            leftSolar.enabled = false;
        }else if(!leftSolar.enabled)
        {
            leftSolar.enabled = true;
        }
        if (rightSolarHP <= 0) 
        {
            rightSolarHP = 0;
            rightSolar.enabled = false;
        }else if(!rightSolar.enabled)
        {
            rightSolar.enabled = true;
        }

        //get lazer input
        if (lazerShotDelay.go() && Input.GetButton("Lazer"))
        {
            if (energy >= 0.25f)
            {
                energy -= 0.25f;
                ShootLazer();
            }

        }
        //get cannon input
        if (cannonReady == false && cannonShotDelay.go()) cannonReady = true;
        if (cannonReady == true && ammo > 0 && Input.GetButton("Cannon"))
        {
            FireCannon();
            cannonReady = false;
            ammo -= 1;
            horizontalMove = new Vector3(horizontalMove.x - 0.5f, horizontalMove.y, horizontalMove.z);
        }

        //check shield toggle status every frame for responsiveness
        if (Input.GetButtonDown("Shield") && shieldActive == false)
        {
            setShieldStatus(true);
        }
        else if (Input.GetButtonDown("Shield") && shieldActive == true)
        {
            setShieldStatus(false);
        }
        if(shieldActive == true && shieldAnimator.currentFrame == shieldAnimator.lastFrame) shieldAnimator.pause = true;


        


        // Energy
        solarEfficiency = (leftSolarHP * 0.5f + rightSolarHP * 0.5f)/100f;
        if( energy < 100f)
        {
            energy += solarEfficiency * 0.01f;
        }
        else
        {
            energy = 100;
        }

        if (energy < 0)
        {
            setShieldStatus(false);
            energy = 0;
        }
        if (energy > 100){
            energy = 100;
        }
        // core HP
        if(HP > 100)
        {
            HP = 100;
        }
        else if (HP <= 0)
        {
            HP = 0;
            //energy = 0;
            //fuel = 0;

        }

        // fuel
        if (fuel > 100){
            fuel = 100;
        }
        else if(fuel < 0){
            fuel = 0;
        }
        
        // Thrusting
        if (fuel > 0.005f)
        {
            if (horizontalMove.x != 0)
            {
                fuel = fuel - 0.00117f;
                if (horizontalMove.x > 0)
                {
                    
                    spaceshipHorizontalSpeed = spaceshipHorizontalSpeed + speedModifier;
                }
                else
                {
                    spaceshipHorizontalSpeed = spaceshipHorizontalSpeed - speedModifier * 0.25f;
                }
            }
            if (verticalMove.y != 0)
            {
                fuel = fuel - 0.00117f;
                if (verticalMove.y > 0)
                {
                    if(spaceshipVerticalSpeed >= 0)
                        spaceshipVerticalSpeed = spaceshipVerticalSpeed + speedModifier * 10f ;
                    else
                        spaceshipVerticalSpeed = spaceshipVerticalSpeed/1.01f + speedModifier * 10f ;
                }
                else
                {
                    if (spaceshipVerticalSpeed <= 0)
                        spaceshipVerticalSpeed = spaceshipVerticalSpeed - speedModifier * 10f;
                    else
                        spaceshipVerticalSpeed = spaceshipVerticalSpeed/1.01f - speedModifier * 10f;
                }
            }
            
        }
        //print(energy);

        // ship movement for testing
        //transform.position += HorizontalMovment();
        transform.position += VertricalMovment();

        // Horizontal movement speed cap
        if (spaceshipHorizontalSpeed > MAX_SPEED)
        {
            spaceshipHorizontalSpeed = MAX_SPEED;
        }

        // Horizontal movement natural slow down
        if(spaceshipHorizontalSpeed > 0)
        {
            spaceshipHorizontalSpeed = spaceshipHorizontalSpeed - speedModifier * 0.05f;
        }
        else if (spaceshipHorizontalSpeed < 0)
        {
            spaceshipHorizontalSpeed = spaceshipHorizontalSpeed + speedModifier * 0.05f;
        }


        // Vertical movement speed cap
        if (spaceshipVerticalSpeed > MAX_SPEED)
        {
            spaceshipVerticalSpeed = MAX_SPEED;
        }

        // Horizontal movement natural slow down
        if (spaceshipVerticalSpeed > 0)
        {
            spaceshipVerticalSpeed = spaceshipVerticalSpeed - speedModifier * 0.05f;
        }
        else if (spaceshipVerticalSpeed < 0)
        {
            spaceshipVerticalSpeed = spaceshipVerticalSpeed + speedModifier * 0.05f;
        }


    }

    public Vector3 HorizontalMovment()
    {
        return (new Vector3(1, 0, 0)) * spaceshipHorizontalSpeed;
    }
    public Vector3 VertricalMovment()
    {
        return (new Vector3(0, 1, 0)) * spaceshipVerticalSpeed * Time.deltaTime;
    }

    void ShootLazer()
    {
        print(lazer);
        Instantiate(lazer, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
    }

    void FireCannon()
    {
        Instantiate(cannon, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
    }
}
