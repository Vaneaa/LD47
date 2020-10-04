using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    SpriteAnimator animator;

    void Start()
    {
        animator = GetComponent<SpriteAnimator>();    
    }

    void Update()
    {
        if (animator.currentFrame == animator.lastFrame) Destroy(this.gameObject);
    }
}
