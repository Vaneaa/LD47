using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicSoundtrack : MonoBehaviour
{

    FrameTimer volumeFade = new FrameTimer(5);

    AudioSource arp;
    AudioSource athmo;
    AudioSource hihat;
    AudioSource kick;
    AudioSource melody;
    AudioSource pulsebass;
    AudioSource snare;
    AudioSource sonar;
    AudioSource subbass;

    Spaceship plr;
    void Start()
    {
        plr = GameObject.Find("Spaceship").GetComponent<Spaceship>();

        arp = transform.GetChild(0).GetComponent<AudioSource>();
        athmo = transform.GetChild(1).GetComponent<AudioSource>();
        hihat = transform.GetChild(2).GetComponent<AudioSource>();
        kick = transform.GetChild(3).GetComponent<AudioSource>();
        melody = transform.GetChild(4).GetComponent<AudioSource>();
        pulsebass = transform.GetChild(5).GetComponent<AudioSource>();
        snare = transform.GetChild(6).GetComponent<AudioSource>();
        sonar = transform.GetChild(7).GetComponent<AudioSource>();
        subbass = transform.GetChild(8).GetComponent<AudioSource>();
    }

    void fadeOut(AudioSource track, float fadeStr)
    {
            if (track.volume > 0) track.volume -= fadeStr;
            else track.volume = 0;
    }

    void Update()
    {
        if(volumeFade.go())
        {
            if (plr.HP < 90)
            {
                fadeOut(melody, 0.005f);
            }
            if (plr.HP < 70)
            {
                fadeOut(pulsebass, 0.01f);
            }
            if (plr.HP < 50)
            {
                fadeOut(arp, 0.01f);
            }
            if (plr.HP < 30)
            {
                fadeOut(snare, 0.01f);
                fadeOut(hihat, 0.01f);
            }
            if (plr.HP < 20)
            {
                fadeOut(athmo, 0.01f);
            }
        }

    }
}
