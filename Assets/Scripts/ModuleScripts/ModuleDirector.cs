using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleDirector : MonoBehaviour
{
    public GameObject[] moduleList;
    GameObject nextModule;
    // Start is called before the first frame update
    void Start()
    {
        moduleList = Resources.LoadAll<GameObject>("Modules");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
