using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseExitToMainMenu : MonoBehaviour {


    public void OnClick()
    {
        LevelScript.levelScript.levelEnd += LoadMainMenu;

        LevelScript.levelScript.OnLevelEnd();
    }
    void LoadMainMenu()
    {
        SceneManager.LoadScene("Main-Menu");
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
