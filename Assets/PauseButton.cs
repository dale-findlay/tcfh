using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour{

    public GameObject pauseMenu;

    public void OnClick()
    {
        foreach (Brother b in GameManager.gameManager.brothers)
        {
            b.characterMove.frozen = true;
        }

        GameManager.gameManager.timer.start = false;

        if(pauseMenu)
        {
            pauseMenu.SetActive(true);
        }
    }


	// Use this for initialization
	void Start () {

        if (pauseMenu)
        {
            pauseMenu.SetActive(false);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
