using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ModuleData : MonoBehaviour
{
    Spaceship plr;
    public ModuleDirector moduleDirector;
    public float speedMod = 0.001f;
    public string type;
    bool dead = false;

    private void Start()
    {
        plr = GameObject.Find("Spaceship").GetComponent<Spaceship>();
        moduleDirector = GameObject.Find("ModuleDirector").GetComponent<ModuleDirector>();
    }

    void Update()
    {
        if(this.transform.position.x < 10 && dead == false)
        {
            //moduleDirector.sampleModuleChoices();
            moduleDirector.selectNextModule();
            dead = true;
        }
        if(this.transform.position.x < -25)
        {
            Destroy(this.gameObject);
        }

        this.transform.position += new Vector3(-(speedMod + (plr.HorizontalMovment().x / 1000)), 0, 0);
    }
}
