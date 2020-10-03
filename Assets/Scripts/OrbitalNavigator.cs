using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalNavigator : MonoBehaviour
{
    GameObject orbitalPath;
    ModuleDirector moduleDirector;
    // Start is called before the first frame update
    void Start()
    {
        orbitalPath = GameObject.Find("OrbitalPath");
        moduleDirector = GameObject.Find("ModuleDirector").GetComponent<ModuleDirector>();
    }

    void calculateOrbitalPath(float velocity)
    {
        int nextModule = (int)Mathf.Floor(velocity);
        moduleDirector.selectNextModule(nextModule);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
