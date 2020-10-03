using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleDirector : MonoBehaviour
{
    public GameObject[] moduleList;
    GameObject nextModule;
    List<GameObject> incomingModules;
    // Start is called before the first frame update
    void Start()
    {
        moduleList = Resources.LoadAll<GameObject>("Modules");
    }

    void sampleModuleChoices()
    {
        List<GameObject> modules = new List<GameObject>();
        for(int i=0; i > 2; i++)
        {
            modules.Add(moduleList[Random.Range(0, moduleList.Length - 1)]);
        }
        incomingModules = modules;
    }

    public void selectNextModule(int next)
    {
        nextModule = incomingModules[next];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
