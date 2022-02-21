using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour {

    public List<AudioClip> crystalPickupSounds = new List<AudioClip>();

    // Use this for initialization
    void Start () {
		


	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Pickup the crystal.
            GameManager.gameManager.crystalCount.crystalCount++;
            Destroy(gameObject);

            int randomSound = UnityEngine.Random.Range(0, crystalPickupSounds.Count - 1);

            AudioManager.audioManager.PushAndPlay(AudioManager.GenerateSourceName("crystal-pickup"), crystalPickupSounds[randomSound]);
        }
    }

    // Update is called once per frame
    void Update () {

        transform.localScale = new Vector3(Mathf.PingPong(Time.time, 0.5f), Mathf.PingPong(Time.time, 0.5f));

    }
}

