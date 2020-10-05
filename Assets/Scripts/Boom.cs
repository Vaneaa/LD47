using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    SpriteAnimator animator;
    AudioSource sfx;
    void Start()
    {
        animator = GetComponent<SpriteAnimator>();
        sfx = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        sfx = GetComponent<AudioSource>();
        sfx.volume = GameObject.Find("Slider").GetComponent<UnityEngine.UI.Slider>().value;
        sfx.Play();
    }

    void Update()
    {
        
        if (animator.currentFrame == animator.lastFrame) Destroy(this.gameObject);
    }
}
