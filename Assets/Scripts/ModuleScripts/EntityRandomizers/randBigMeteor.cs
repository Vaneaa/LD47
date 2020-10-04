using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randBigMeteor : MonoBehaviour
{
    HazardRandomizer hazRan;
    void Start()
    {
        hazRan = GameObject.Find("HazardRandomizer").GetComponent<HazardRandomizer>();
        gameObject.GetComponent<SpriteRenderer>().sprite = hazRan.getRandomBigMeteor();
    }
}
