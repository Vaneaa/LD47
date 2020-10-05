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
        if(value < 0.20f && fuelDrop != null)
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
