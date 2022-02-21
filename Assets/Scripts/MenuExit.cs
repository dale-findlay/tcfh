using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuExit : MonoBehaviour {

    public void Exit()
    {
        Application.Quit();
    }

    public void OnClick()
    {
        AudioManager.audioManager.RemoveFadeOut("main-menu-music");
        LevelScript.levelScript.levelEnd += Exit;
        LevelScript.levelScript.OnLevelEnd();
    }
}
