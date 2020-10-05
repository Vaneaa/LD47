using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModuleDirector : MonoBehaviour
{
    FrameTimer moduleSpawnRate = new FrameTimer(240);
    Spaceship plr;
    public GameObject[] moduleList;
    GameObject nextModule;
    public List<GameObject> incomingModules;
    float totalSpeedMod = 0.1f;
    FrameTimer typeTimer = new FrameTimer(800); //selection phase begins.
    FrameTimer changeTypeTimer = new FrameTimer(1200);
    bool choosingPath = false;
    public List<GameObject> selectedModuleType = new List<GameObject>();
    PathUI pathui;

    public int modulesCompleted = 0;
    public bool victory = false;
    // Start is called before the first frame update
    void Start()
    {
        pathui = GameObject.Find("UpcomingModulePaths").GetComponent<PathUI>();
        plr = GameObject.Find("Spaceship").GetComponent<Spaceship>();
        moduleList = Resources.LoadAll<GameObject>("Modules");
        setModuleType("a");
    }

    public void sampleModuleChoices()
    {
        List<GameObject> modules = new List<GameObject>();
        for(int i=0; i < 3; i++)
        {
            modules.Add(moduleList[Random.Range(0, moduleList.Length)]);
            print("module added to pool");
        }
        incomingModules = modules;
    }

    public void setModuleType(string type)
    {
        List<GameObject> typePool = new List<GameObject>();
        foreach(GameObject module in moduleList)
        {
            if(module.GetComponent<ModuleData>().type == type)
            {
                typePool.Add(module);
            }
        }
        selectedModuleType = typePool;
    }

    public void selectNextModule()
    {
        /*
        if(totalSpeedMod < 0.15)
        {
            totalSpeedMod += 0.05f;
        }
        */
        print("module generated.");
        nextModule = selectedModuleType[Random.Range(0, selectedModuleType.Count-1)];
        GameObject module = Instantiate(nextModule, new Vector3(30, 0, 0), Quaternion.identity);
        module.GetComponent<ModuleData>().moduleDirector = this.gameObject.GetComponent<ModuleDirector>();
    }
    int getStationCourse()
    {
        return (int)Mathf.Floor(plr.spaceshipHorizontalSpeed / 4);
    }
    void Update()
    {
        if(victory)
        {
            SceneManager.LoadScene("Victory");
        }
        if(moduleSpawnRate.go())
        {
            selectNextModule();
        }

        if (getStationCourse() == 0) pathui.p1.color = new Color(0.7f, 0.7f, 0.0f); else pathui.p1.color = new Color(0.0f, 0.7f, 0.0f);
        if (getStationCourse() == 1) pathui.p2.color = new Color(0.7f, 0.7f, 0.0f); else pathui.p2.color = new Color(0.0f, 0.7f, 0.0f);
        if (getStationCourse() == 2) pathui.p3.color = new Color(0.7f, 0.7f, 0.0f); else pathui.p3.color = new Color(0.0f, 0.7f, 0.0f);

        if (typeTimer.go() && choosingPath == false)
        {
            sampleModuleChoices();
            pathui.p1.text = incomingModules[0].GetComponent<ModuleData>().type + " || target velocity: 0.0 - 3.9";
            pathui.p2.text = incomingModules[1].GetComponent<ModuleData>().type + " || target velocity: 4.0 - 7.9";
            pathui.p3.text = incomingModules[2].GetComponent<ModuleData>().type + " || target velocity: 8.0 - 12.0";
            choosingPath = true;
        }

        if (choosingPath == true && changeTypeTimer.go())
        {
            pathui.p1.text = "";
            pathui.p2.text = "";
            pathui.p3.text = "";
            int next = getStationCourse();
            print("plr.spaceshipHorizontalSpeed/4 : " + next.ToString());
            setModuleType(incomingModules[next].GetComponent<ModuleData>().type);
            modulesCompleted += 1;
            if (modulesCompleted >= 10) victory = true;
            choosingPath = false;
        }
    }
}
