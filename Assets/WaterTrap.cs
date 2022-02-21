using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrap : TrapBase {

    public int speedDemultiplier = 2;
    public AudioClip wadingSound;

    string sourceName = null;

    public override void Start()
    {
        base.Start();

        onTrappedStart += WaterTrapEntered;
        onTrappedExit += WaterTrapExit;
    }

    void WaterTrapEntered(Brother b)
    {
        sourceName = AudioManager.GenerateSourceName("water-wading");

        AudioManager.audioManager.PushAndPlay(sourceName, wadingSound, true);

        foreach (Brother brother in GameManager.gameManager.brothers)
        {
            brother.characterMove.moveSpeed -= speedDemultiplier;
        }
    }

    void WaterTrapExit(Brother b)
    {
        AudioManager.audioManager.RemoveFadeOut(sourceName);

        foreach (Brother brother in GameManager.gameManager.brothers)
        {
            brother.characterMove.moveSpeed += speedDemultiplier;
        }
    }

    //Update is called once per frame
    void Update () {
		
	}
}
