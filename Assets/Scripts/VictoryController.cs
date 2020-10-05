using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryController : MonoBehaviour
{
    DynamicSoundtrack dynSound;
    // Start is called before the first frame update
    void Start()
    {
        dynSound = GameObject.Find("DynamicSoundtrack").GetComponent<DynamicSoundtrack>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toMenu()
    {
        if (dynSound != null) dynSound.onMenu();
        SceneManager.LoadScene("Title");
    }
}
