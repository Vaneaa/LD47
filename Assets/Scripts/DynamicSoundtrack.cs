using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicSoundtrack : MonoBehaviour
{

    FrameTimer volumeFade = new FrameTimer(5);
    UnityEngine.UI.Slider volumeSlider;
    float volPercent = 0.5f;

    AudioSource arp;
    AudioSource athmo;
    AudioSource hihat;
    AudioSource kick;
    AudioSource melody;
    AudioSource pulsebass;
    AudioSource snare;
    AudioSource sonar;
    AudioSource subbass;

    bool fadeMelody = false;
    bool fadePulsebass = false;
    bool fadeArp = false;
    bool fadeSnareHat = false;
    bool fadeAthmo = false;

    Spaceship plr;
    void Start()
    {
        //plr = GameObject.Find("Spaceship").GetComponent<Spaceship>();
        volumeSlider = GameObject.Find("Slider").GetComponent<UnityEngine.UI.Slider>();
        volumeSlider.value = volPercent;
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

    void adjustVolume()
    {
        volPercent = volumeSlider.value;
        if (melody.volume > 0 && fadeMelody == false) melody.volume = volPercent;
        if (pulsebass.volume > 0 && fadePulsebass == false) pulsebass.volume = volPercent;
        if (arp.volume > 0 && fadeArp == false) arp.volume = volPercent;
        if (snare.volume > 0 && fadeSnareHat == false) snare.volume = volPercent;
        if (hihat.volume > 0 && fadeSnareHat == false) hihat.volume = volPercent;
        if (athmo.volume > 0 && fadeAthmo == false) athmo.volume = volPercent;
        kick.volume = volPercent;
        sonar.volume = volPercent;
        subbass.volume = volPercent;
    }

    public void onPlay()
    {
        melody.volume = volPercent;
        pulsebass.volume = volPercent;
        arp.volume = volPercent;
        snare.volume = volPercent;
        hihat.volume = volPercent;
        athmo.volume = volPercent;
        kick.volume = volPercent;
        sonar.volume = volPercent;
        subbass.volume = volPercent;
    }

    public void onMenu()
    {
        melody.volume = volPercent;
        pulsebass.volume = 0;
        arp.volume = 0;
        snare.volume = 0;
        hihat.volume = 0;
        athmo.volume = 0;
        kick.volume = volPercent;
        sonar.volume = volPercent;
        subbass.volume = volPercent;
    }

    void Update()
    {
        if(GameObject.Find("Spaceship"))
        {
            plr = GameObject.Find("Spaceship").GetComponent<Spaceship>();
        }
        adjustVolume();

        if(plr != null && volumeFade.go())
        {
            if (plr.HP < 90)
            {
                fadeOut(melody, 0.005f);
                fadeMelody = true;
            }
            if (plr.HP < 70)
            {
                fadeOut(pulsebass, 0.01f);
                fadePulsebass = true;
            }
            if (plr.HP < 50)
            {
                fadeOut(arp, 0.01f);
                fadeArp = true;
            }
            if (plr.HP < 30)
            {
                fadeOut(snare, 0.01f);
                fadeOut(hihat, 0.01f);
                fadeSnareHat = true;
            }
            if (plr.HP < 20)
            {
                fadeOut(athmo, 0.01f);
                fadeAthmo = true;
            }
        }

    }
}
