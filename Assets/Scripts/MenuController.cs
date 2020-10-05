using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    GameObject help;
    public GameObject dynSound;
    // Start is called before the first frame update
    void Start()
    {
        help = transform.GetChild(1).gameObject;
        if(!GameObject.Find("PreservedCanvas"))
        {
            GameObject obj = GameObject.Instantiate(dynSound, transform.position, Quaternion.identity);
            obj.name = "PreservedCanvas";
            DontDestroyOnLoad(obj);

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        print("button clicked.");
        GameObject.Find("DynamicSoundtrack").GetComponent<DynamicSoundtrack>().onPlay();
        SceneManager.LoadScene("Hannah");
    }
}
