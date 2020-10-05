using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speed : MonoBehaviour
{
    private Spaceship player;
    private Slider speed;
    // Start is called before the first frame update
    void Start()
    {
        speed= GameObject.Find("Speed").GetComponent<Slider>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Spaceship>();
        
    }

    // Update is called once per frame
    void Update()
    {
        speed.value = player.spaceshipHorizontalSpeed/player.MAX_SPEED;
    }
}
