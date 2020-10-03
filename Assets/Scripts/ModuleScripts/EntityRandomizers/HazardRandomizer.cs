using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/***
 * this is a data contained for loading sprites used in
 * randomizing hazard appearances.
 * these sprties should only be loaded here otherwise it will cause performance drops.
 * 
 * some functions for grabbing a random sprite are housed here, too
 ***/ 
public class HazardRandomizer : MonoBehaviour
{
    public Sprite[] satellites;
    public Sprite[] medMeteors;
    public Sprite[] smlMeteors;
    public Sprite[] clouds;
    // Start is called before the first frame update
    void Start()
    {
        satellites = Resources.LoadAll<Sprite>("PixelArt/satellites");
        medMeteors = Resources.LoadAll<Sprite>("PixelArt/Med_Meteors");
        smlMeteors = Resources.LoadAll<Sprite>("PixelArt/Sml_Meteors");
        clouds = Resources.LoadAll<Sprite>("PixelArt/Particulate_Clouds");
    }

    public Sprite getRandomSatellite()
    {
        return satellites[Random.Range(0, satellites.Length)];
    }

    public Sprite getRandomMedMeteor()
    {
        return medMeteors[Random.Range(0, medMeteors.Length)];
    }

    public Sprite getRandomSmlMeteor()
    {
        return smlMeteors[Random.Range(0, smlMeteors.Length)];
    }

    public Sprite getRandomCloud()
    {
        return clouds[Random.Range(0, clouds.Length)];
    }
}
