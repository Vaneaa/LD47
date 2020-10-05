using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    private Spaceship player;
    private Slider energy;
    // Start is called before the first frame update
    void Start()
    {
        energy= GameObject.Find("Energy").GetComponent<Slider>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Spaceship>();
        
    }

    // Update is called once per frame
    void Update()
    {
        energy.value = player.energy/100;
    }
}
