using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletsPanel : MonoBehaviour
{
    private Spaceship player;
    private Image[] bullets;
    // Start is called before the first frame update
    void Start()
    {
        bullets = new Image[3];

        bullets[0]= GameObject.Find("bullet1").GetComponent<Image>();
        bullets[1]= GameObject.Find("bullet2").GetComponent<Image>();
        bullets[2]= GameObject.Find("bullet3").GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Spaceship>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.ammo == 0)
        {
            foreach(Image bullet in bullets){
                bullet.enabled = false;
            }
        }if(player.ammo > 0){
            bullets[0].enabled = true;
        }else{
            bullets[0].enabled = false;
        }
        if(player.ammo > 1){
            bullets[1].enabled = true;
        }else{
            bullets[1].enabled = false;
        }
        if(player.ammo > 2){
            bullets[2].enabled = true;
        }else{
            bullets[2].enabled = false;
        }
    }
}
