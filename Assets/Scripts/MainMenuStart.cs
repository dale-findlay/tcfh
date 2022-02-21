using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuStart : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadLevel()
    {
        SceneManager.LoadScene("GameLevel");
    }

    public void OnClick()
    {
        AudioManager.audioManager.RemoveFadeOut("main-menu-music");
        LevelScript.levelScript.levelEnd += LoadLevel;
        LevelScript.levelScript.OnLevelEnd();
    }
}
