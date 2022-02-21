using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpriteSpawner : MonoBehaviour {

    public List<Sprite> sprites = new List<Sprite>();
   
    void SpawnNewSprite()
    {
        int randomInt = Random.Range(0, sprites.Count - 1);

        float randomScale = Random.Range(0.5f, 1);

        GameObject gm = new GameObject();

        gm.transform.position = transform.position;
        gm.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
        
        SpriteRenderer r = gm.AddComponent<SpriteRenderer>();
        r.sprite = sprites[randomInt];

        Rigidbody rb = gm.AddComponent<Rigidbody>();
        rb.velocity = new Vector3(-5, 5, -5);
        rb.useGravity = false;


    }

    
    // Use this for initialization
	void Start () {

        InvokeRepeating("SpawnNewSprite", 3, 3);
	}
	
	// Update is called once per frame
	void Update () {		
	}
}
