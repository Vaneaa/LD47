using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpaceshipControls : MonoBehaviour
{

    float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        transform.position += move * speed * Time.deltaTime;
    }
}
