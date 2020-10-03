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
    void Start()
    {
        plr = GameObject.FindGameObjectWithTag("Player");
        speedBonus = Random.Range(speedBonusMin, speedBonusMax);
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < plr.transform.position.x + 0.5 && transform.position.x > plr.transform.position.x - 0.5
            && transform.position.y < plr.transform.position.y + 1 && transform.position.y > plr.transform.position.y - 1)
        {
            //check for solar array hits on player
            if(transform.position.y > plr.transform.position.y + 0.1f)
            {
                //solar array L hit
            }
            else if(transform.position.y < plr.transform.position.y - 0.1f)
            {
                //solar array R hit
            }

            //player damage here
            print("station hit!");
            Destroy(this.gameObject);
        }
        transform.position = new Vector2(transform.position.x - (speed + speedBonus ) * Time.deltaTime, transform.position.y);
    }
}
