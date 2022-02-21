using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : TrapBase {

    public float ouchieTime = 2.0f;
    
    public Sprite openSprite;
    public Sprite closeSprite;

    public AudioClip activatedSound;

    public bool activated = false;

    private SpriteRenderer spriteRenderer;

    public override void Start() 
    {
        base.Start();

        spriteRenderer = GetComponent<SpriteRenderer>();
        //add this to the list of things to do when the player enters the trap.
        onTrappedStart += PausePlayerMove;
    }

    public IEnumerator FreezePlayer(float freezeSeconds)
    {
        foreach(Brother b in GameManager.gameManager.brothers)
        {
            b.characterMove.frozen = true;
        }
        
        spriteRenderer.sprite = closeSprite;

        Brother brother = GameManager.gameManager.brothers[0];
        brother.Hurt();

        AudioManager.audioManager.PushAndPlay(AudioManager.GenerateSourceName("bt-activate"), activatedSound);

        yield return new WaitForSeconds(freezeSeconds);

        activated = true;

        foreach (Brother b in GameManager.gameManager.brothers)
        {
            b.characterMove.frozen = false;
        }
    }

    public void PausePlayerMove(Brother b)
    {
        if (activated == false)
        {
            StartCoroutine(FreezePlayer(ouchieTime));
        }
    }


}
