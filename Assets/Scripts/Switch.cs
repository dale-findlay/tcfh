using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class Switch : MonoBehaviour {

    public UnityEvent onSwitchStateChange;

    public AudioClip switchSound;

    bool playerCanInteract = false;

    public bool isActive = false;

    public Sprite onSprite;
    public Sprite offSprite;

    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerCanInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerCanInteract = false;
        }

    }

    private void SwitchSprite()
    {
        if (isActive)
        {
            //switch to close sprite.
            spriteRenderer.sprite = offSprite;
            isActive = false;
        }
        else
        {
            //switch to open sprite.
            spriteRenderer.sprite = onSprite;
            isActive = true;
        }

        string hashedTimeName = AudioManager.GenerateSourceName("lever-sound");

        AudioManager.audioManager.PushAndPlay(hashedTimeName, switchSound);
    }

    // Update is called once per frame
    void Update () {
		
        if(playerCanInteract)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                //The player interacted.

                SwitchSprite();

                onSwitchStateChange.Invoke();

            }
        }

	}
}
