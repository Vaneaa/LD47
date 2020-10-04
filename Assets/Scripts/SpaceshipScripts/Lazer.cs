using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    FrameTimer garbageCollector = new FrameTimer(700);
    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles += new Vector3(0, 0, 0) ;
    }

    // Update is called once per frame
    void Update()
    {
        ///transform.eulerAngles += new Vector3(0, 0, 1);
        transform.position += (new Vector3(1, 0, 0)) * 10 * Time.deltaTime;
        if(garbageCollector.go())
        {
            Destroy(this.gameObject);
        }
    }
}
 