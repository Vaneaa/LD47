﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    //editor configurable values
    public float speed = 0.1f;
    public float hitboxSize = 1f;
    public float speedBonusMax = 1f;
    public float speedBonusMin = 0.1f;
    public float shieldDamageMod = 0f;
    float speedBonus;
    public int hp = 1;
    protected GameObject plr;
    public delegate void onCollide();
    protected onCollide collideBase;
    protected onCollide collideSAL;
    protected onCollide collideSAR;
    protected onCollide collideLazer;
    protected onCollide collideCannon;
    protected onCollide collideShield;

    protected bool canStopProjectiles = true;

    void defaultCollideBase()
    {
        if (plr.GetComponent<Spaceship>().shieldActive == false) plr.GetComponent<Spaceship>().HP -= 15;
        else plr.GetComponent<Spaceship>().energy -= hp + shieldDamageMod;

        Destroy(this.gameObject);
    }
    void defaultCollideSAL()
    {
        //solar array L collision
        if (plr.GetComponent<Spaceship>().shieldActive == false)  plr.GetComponent<Spaceship>().leftSolarHP -= 15;
        else plr.GetComponent<Spaceship>().energy -= hp + shieldDamageMod;
        Destroy(this.gameObject);
    }
    void defaultCollideSAR()
    {
        //solar array R collision
        if (plr.GetComponent<Spaceship>().shieldActive == false) plr.GetComponent<Spaceship>().rightSolarHP -= 15;
        else plr.GetComponent<Spaceship>().energy -= hp + shieldDamageMod;
        Destroy(this.gameObject);
    }
    void defaultLazerCollide()
    {
        hp -= 1;
    }
    void defaultCannonCollide()
    {
        hp -= 20;
    }
    void defaultShieldCollide()
    {
        Destroy(this.gameObject);
    }



    protected void init() //place inside Start() to facilitate easy children
    {
        collideBase = new onCollide(defaultCollideBase);
        collideSAL = new onCollide(defaultCollideSAL);
        collideSAR = new onCollide(defaultCollideSAR);
        collideLazer = new onCollide(defaultLazerCollide);
        collideCannon = new onCollide(defaultCannonCollide);
        collideShield = new onCollide(defaultShieldCollide);
        plr = GameObject.FindGameObjectWithTag("Player");
        speedBonus = Random.Range(speedBonusMin, speedBonusMax);
    }
    protected void run() //place inside Start() to facilitate easy children
    {
        //weapon collisions
        GameObject[] lazerList = GameObject.FindGameObjectsWithTag("Lazer");
        GameObject[] cannonList = GameObject.FindGameObjectsWithTag("Cannon");
        foreach (GameObject proj in lazerList)
        {
            if(Vector2.Distance(this.transform.position, proj.transform.position) < 0.7f)
            {
                if (canStopProjectiles) Destroy(proj);
                collideLazer();
            }
        }

        foreach (GameObject proj in cannonList)
        {
            if (Vector2.Distance(this.transform.position, proj.transform.position) < 1f)
            {
                if (canStopProjectiles) Destroy(proj);
                collideCannon();
            }
        }

        if (hp <= 0) Explode();

        //player collisions
        if (transform.position.x - hitboxSize < plr.transform.position.x + 0.5 && transform.position.x + hitboxSize > plr.transform.position.x - 0.5
            && transform.position.y - hitboxSize < plr.transform.position.y + 1 && transform.position.y + hitboxSize > plr.transform.position.y - 1)
        {
            //check for solar array hits on player
            if (transform.position.y + hitboxSize > plr.transform.position.y + 0.1f && plr.GetComponent<Spaceship>().leftSolarHP > 0)
            {
                //solar array L hit
                collideSAL();
            }
            else if (transform.position.y - hitboxSize < plr.transform.position.y - 0.1f && plr.GetComponent<Spaceship>().rightSolarHP > 0)
            {
                //solar array R hit
                collideSAR();
            }else
            {
                collideBase();
            }

            //player damage here

        }
        transform.position = new Vector2(transform.position.x - (speed + speedBonus + plr.GetComponent<Spaceship>().HorizontalMovment().x) * Time.deltaTime, transform.position.y);
    }
   
    protected void Explode()
    {
        Destroy(this.gameObject);
    }

    void Start()
    {
        init();
    }
    void Update()
    {
        run();
    }
}
