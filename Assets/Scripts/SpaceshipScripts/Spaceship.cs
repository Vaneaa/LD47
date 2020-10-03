using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class Spaceship : MonoBehaviour
{

    public float spaceshipHorizontalSpeed = 0;
    public static float spaceshipVerticalSpeed = 0;
    public const float MAX_SPEED = 12;
    float speedModifier = 0.005f;

    public float fuel = 100f;

    public Lazer lazer;

    // Start is called before the first frame update
    void Start()
    {
        lazer = Resources.LoadAll<Lazer>("Lazer")[0];
        //lazer = GameObject.Find("Lazer").GetComponent<Lazer>();

    }

    void   FixedUpdate()
    {
        if (Input.GetKey("space") || Input.GetKey("z"))
        {
            print("Space was pressed");
            ShootLazer();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 horizontalMove = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        Vector3 verticalMove = new Vector3(0, Input.GetAxis("Vertical"), 0);

        // lazer
        
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
                    spaceshipVerticalSpeed = spaceshipVerticalSpeed + speedModifier * 1.5f ;
                }
                else
                {
                    spaceshipVerticalSpeed = spaceshipVerticalSpeed - speedModifier * 1.5f;
                }
            }
            ;
        }
        //print(fuel);

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
}
