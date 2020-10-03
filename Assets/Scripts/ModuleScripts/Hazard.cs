using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    //editor configurable values
    public float speed = 0.1f;
    public float hitboxSize = 0.3f;
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
    private void FixedUpdate()
    {
        if(Vector2.Distance(this.transform.position,plr.transform.position) < hitboxSize)
        {
            //player damage here
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - (speed + speedBonus) * Time.deltaTime);
    }
}
