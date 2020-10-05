using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxContainer : MonoBehaviour
{
    AudioSource sfx;
    FrameTimer timeout = new FrameTimer(360);
    void Start()
    {
        sfx = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        sfx = GetComponent<AudioSource>();
        sfx.volume = GameObject.Find("Slider").GetComponent<UnityEngine.UI.Slider>().value / 2f;
        sfx.Play();
    }

    void Update()
    {

        if(timeout.go())
        {
            Destroy(this.gameObject);
        }
    }
}
