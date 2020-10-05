using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthAnim : MonoBehaviour
{

    public SpriteRenderer[] sprites;

    private float timer = 0;
    private int counter = 0;
    float timeStart;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        timeStart = Time.time;
        sprites = new SpriteRenderer[14];
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i] = GameObject.Find("Earth" + i.ToString()).GetComponent<SpriteRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //print("timer " + timer);
        if (counter < 14)
        {
            if ((int)timer % 2 == 0)
            {
                timer++;
                for (int i = 0; i < sprites.Length; i++)
                {
                    sprites[i].enabled = false;
                }
                sprites[counter].enabled = true;
                print("timer " + timer);
                print("counter " + counter);
                //print("Time Delta " + Time.deltaTime);
                counter++;
            }
        }else{
            sprites[13].enabled = true;
        }
    }
}
