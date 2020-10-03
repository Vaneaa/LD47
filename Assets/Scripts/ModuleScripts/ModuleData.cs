using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ModuleData : MonoBehaviour
{
    public ModuleDirector moduleDirector;
    public float speedMod = 0.005f;
    bool dead = false;

    private void Start()
    {
        moduleDirector = GameObject.Find("ModuleDirector").GetComponent<ModuleDirector>();
    }

    void Update()
    {
        if(this.transform.position.x < 0 && dead == false)
        {
            moduleDirector.sampleModuleChoices();
            moduleDirector.selectNextModule();
            dead = true;
        }
        if(this.transform.position.x < -25)
        {
            Destroy(this.gameObject);
        }

        this.transform.position += new Vector3(-speedMod, 0, 0);
    }
}
