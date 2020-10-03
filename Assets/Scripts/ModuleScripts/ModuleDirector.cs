using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleDirector : MonoBehaviour
{
    Spaceship plr;
    public GameObject[] moduleList;
    GameObject nextModule;
    List<GameObject> incomingModules;
    float totalSpeedMod = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        plr = GameObject.Find("Spaceship").GetComponent<Spaceship>();
        moduleList = Resources.LoadAll<GameObject>("Modules");
    }

    public void sampleModuleChoices()
    {
        List<GameObject> modules = new List<GameObject>();
        for(int i=0; i < 2; i++)
        {
            modules.Add(moduleList[Random.Range(0, moduleList.Length)]);
            print("module added to pool");
        }
        incomingModules = modules;
    }

    public void selectNextModule()
    {
        if(totalSpeedMod < 0.15)
        {
            totalSpeedMod += 0.05f;
        }
        print("# of modules" + incomingModules.Count.ToString());
        int next = (int)Mathf.Floor(plr.spaceshipHorizontalSpeed / 12);
        nextModule = incomingModules[next];
        GameObject module = Instantiate(nextModule, new Vector3(25, 0, 0), Quaternion.identity);
        module.GetComponent<ModuleData>().moduleDirector = this.gameObject.GetComponent<ModuleDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
