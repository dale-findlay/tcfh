using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public class Gate : MonoBehaviour {

    public bool isOpen = false;

    public Sprite openSprite;
    public Sprite closeSprite;

    private SpriteRenderer spriteRenderer;

    // Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnSwitchStateChange()
    {
        if(isOpen)
        {
            //switch to close sprite.
            spriteRenderer.sprite = closeSprite;
            isOpen = false;
            GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            //switch to open sprite.
            spriteRenderer.sprite = openSprite;
            isOpen = true;
            GetComponent<BoxCollider2D>().enabled = false;
        }        

    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
