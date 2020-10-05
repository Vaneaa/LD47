using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazSat : Hazard
{
    public GameObject energyDrop;
    public GameObject fuelDrop;
    private void OnDestroy()
    {
        float value = Random.Range(0f, 1f);
        print("rng value: " + value);
        if(value < 0.05f && fuelDrop != null)
        {
            
            Instantiate(energyDrop, transform.position, Quaternion.identity);
        }
        else if(value < 0.2f && energyDrop != null)
        {
            Instantiate(fuelDrop, transform.position, Quaternion.identity);
        }
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
