using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randMedMeteor : MonoBehaviour
{
    HazardRandomizer hazRan;
    void Start()
    {
        hazRan = GameObject.Find("HazardRandomizer").GetComponent<HazardRandomizer>();
        gameObject.GetComponent<SpriteRenderer>().sprite = hazRan.getRandomMedMeteor();
    }
}
