using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFadeIn : MonoBehaviour {

    public List<FadeIn> fadeInItems = new List<FadeIn>();
    public bool done = false;

    public bool start = false;

    void Start()
    {
        
    }

    public void Freeze()
    {
        foreach (FadeIn fadeIn in fadeInItems)
        {
            fadeIn.enabled = false;
        }
    }

    public void Update()
    {
        if(start)
        {
            StartLevelFadeIn();
            start = false;
        }
    }

    public void StartLevelFadeIn()
    {     
        foreach(FadeIn fadeIn in fadeInItems)
        {
            fadeIn.start = true;

            if(fadeIn.done)
            {
                fadeIn.enabled = false;
                done = true;
            }
            else
            {
                done = false;
            }
        }

        if(done)
        {
            enabled = false;
        }
    }

}
