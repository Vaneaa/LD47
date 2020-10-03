using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    //editor configurable values
    public float speed = 0.1f;
    public float hitboxSize = 1f;
    public float speedBonusMax = 1f;
    public float speedBonusMin = 0.1f;
    float speedBonus;
    public int hp = 1;
    GameObject plr;
    public delegate void onCollide();
    protected onCollide collideBase;
    protected onCollide collideSAL;
    protected onCollide collideSAR;

    void defaultCollideBase()
    {
        print("station hit!");
        Destroy(this.gameObject);
    }
    void defaultCollideSAL()
    {
        //solar array L collision
    }
    void defaultCollideSAR()
    {
        //solar array R collision
    }



    protected void init() //place inside Start() to facilitate easy children
    {
        collideBase = new onCollide(defaultCollideBase);
        collideSAL = new onCollide(defaultCollideSAL);
        collideSAR = new onCollide(defaultCollideSAR);
        plr = GameObject.FindGameObjectWithTag("Player");
        speedBonus = Random.Range(speedBonusMin, speedBonusMax);
    }
    protected void run() //place inside Start() to facilitate easy children
    {
        if (transform.position.x < plr.transform.position.x + 0.5 && transform.position.x > plr.transform.position.x - 0.5
            && transform.position.y < plr.transform.position.y + 1 && transform.position.y > plr.transform.position.y - 1)
        {
            //check for solar array hits on player
            if (transform.position.y > plr.transform.position.y + 0.1f)
            {
                //solar array L hit
                collideSAL();
            }
            else if (transform.position.y < plr.transform.position.y - 0.1f)
            {
                //solar array R hit
                collideSAR();
            }

            //player damage here
            collideBase();
        }
        transform.position = new Vector2(transform.position.x - (speed + speedBonus + plr.GetComponent<Spaceship>().HorizontalMovment().x) * Time.deltaTime, transform.position.y);
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
