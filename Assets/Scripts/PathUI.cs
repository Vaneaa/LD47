using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathUI : MonoBehaviour
{
    public UnityEngine.UI.Text p1;
    public UnityEngine.UI.Text p2;
    public UnityEngine.UI.Text p3;
    ModuleDirector director;
    // Start is called before the first frame update
    void Start()
    {
        p1 = GameObject.Find("Path1").GetComponent<UnityEngine.UI.Text>();
        p2 = GameObject.Find("Path2").GetComponent<UnityEngine.UI.Text>();
        p3 = GameObject.Find("Path3").GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
