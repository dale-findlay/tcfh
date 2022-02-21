using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevelScript : LevelScript {

    public AudioClip levelMusic;

    private void Awake()
    {
        base.AwakeScript();
    }

    // Use this for initialization
    void Start () {

        OnLevelLoad();

        AudioManager.audioManager.PushAndPlay("level-music", levelMusic, true);

        levelEnd += RemoveFadeOutMusic;

    }

    private void RemoveFadeOutMusic()
    {
        AudioManager.audioManager.RemoveFadeOut("level-music");
    }
    

    // Update is called once per frame
    void Update () {
		
	}
}