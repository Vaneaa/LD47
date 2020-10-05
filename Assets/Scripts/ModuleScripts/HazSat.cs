using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazSat : Hazard
{
    GameObject energyDrop;
    GameObject fuelDrop;
    private void OnDestroy()
    {
        if(Random.Range(0,1) < 0.1f && fuelDrop != null)
        {
            Instantiate(fuelDrop, transform.position, Quaternion.identity);
        }
        else if(Random.Range(0,1) < 0.2f && energyDrop != null)
        {
            Instantiate(energyDrop, transform.position, Quaternion.identity);
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
