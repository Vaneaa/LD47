using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    private Spaceship player;
    private Slider hp;
    // Start is called before the first frame update
    void Start()
    {
        hp= GameObject.Find("HP").GetComponent<Slider>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Spaceship>();
        
    }

    // Update is called once per frame
    void Update()
    {
        hp.value = player.HP/100;
    }
}
