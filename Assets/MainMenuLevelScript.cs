using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuLevelScript : LevelScript {

    public AudioClip musicClip; 

	// Use this for initialization
	void Start () {

        OnLevelLoad();

        AudioManager.audioManager.PushAndPlay("main-menu-music", musicClip, true);
    }

    private void Awake()
    {
        base.AwakeScript();
    }

    // Update is called once per frame
    void Update () {
		
        

	}
}
