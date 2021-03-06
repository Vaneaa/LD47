﻿using System.Collections;
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

    public AudioClip _arp;
    public AudioClip _athmo;
    public AudioClip _hihat;
    public AudioClip _kick;
    public AudioClip _melody;
    public AudioClip _pulsebass;
    public AudioClip _snare;
    public AudioClip _sonar;
    public AudioClip _subbass;

    bool fadeMelody = false;
    bool fadePulsebass = false;
    bool fadeArp = false;
    bool fadeSnareHat = false;
    bool fadeAthmo = false;

    bool loaded = false;

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

        _arp = Resources.Load<AudioClip>("Soundtrack/tracklist/arp");
        _athmo = Resources.Load<AudioClip>("Soundtrack/tracklist/athmo");
        _hihat = Resources.Load<AudioClip>("Soundtrack/tracklist/hi-hat");
        _kick = Resources.Load<AudioClip>("Soundtrack/tracklist/heartbeat");
        _melody = Resources.Load<AudioClip>("Soundtrack/tracklist/melody");
        _pulsebass = Resources.Load<AudioClip>("Soundtrack/tracklist/pulse_bass");
        _snare = Resources.Load<AudioClip>("Soundtrack/tracklist/snare");
        _sonar = Resources.Load<AudioClip>("Soundtrack/tracklist/sonar");
        _subbass = Resources.Load<AudioClip>("Soundtrack/tracklist/sub");
    }


    void checkLoadStatus()
    {
        if (loaded == false &&
            _arp.loadState == AudioDataLoadState.Loaded &&
            _athmo.loadState == AudioDataLoadState.Loaded &&
            _hihat.loadState == AudioDataLoadState.Loaded &&
            _kick.loadState == AudioDataLoadState.Loaded &&
            _melody.loadState == AudioDataLoadState.Loaded&&
            _pulsebass.loadState == AudioDataLoadState.Loaded&&
            _snare.loadState == AudioDataLoadState.Loaded &&
            _subbass.loadState == AudioDataLoadState.Loaded)
        {

            arp.clip = _arp;
            athmo.clip = _athmo;
            hihat.clip = _hihat;
            kick.clip = _kick;
            melody.clip = _melody;
            pulsebass.clip = _pulsebass;
            snare.clip = _snare;
            sonar.clip = _sonar;
            subbass.clip = _subbass;

            loaded = true;
            arp.Play();
            athmo.Play();
            hihat.Play();
            kick.Play();
            melody.Play();
            pulsebass.Play();
            snare.Play();
            sonar.Play();
            subbass.Play();
        }
    }

    void fadeOut(AudioSource track, float fadeStr)
    {
            if (track.volume > 0) track.volume -= fadeStr;
            else track.volume = 0;
    }

    void adjustVolume()
    {
        volPercent = volumeSlider.value;
        if (fadeMelody == false) melody.volume = volPercent;
        if (fadePulsebass == false) pulsebass.volume = volPercent;
        if (fadeArp == false) arp.volume = volPercent;
        if (fadeSnareHat == false) snare.volume = volPercent;
        if (fadeSnareHat == false) hihat.volume = volPercent;
        if (fadeAthmo == false) athmo.volume = volPercent;
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
        melody.volume = 0;
        pulsebass.volume = 0;
        arp.volume = 0;
        snare.volume = 0;
        hihat.volume = 0;
        athmo.volume = 0;
        kick.volume = volPercent;
        sonar.volume = volPercent;
        subbass.volume = volPercent;
    }

    public void onVictory()
    {
        fadeMelody = false;
        fadePulsebass = false;
        fadeArp = false;
        fadeSnareHat = false;
        fadeAthmo = false;
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


    void Update()
    {
        checkLoadStatus();
        if(loaded == true)
        {
            if (GameObject.Find("Spaceship"))
            {
                plr = GameObject.Find("Spaceship").GetComponent<Spaceship>();
            }
            adjustVolume();

            if (plr != null && volumeFade.go())
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
}
