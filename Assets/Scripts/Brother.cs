using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
[System.Serializable]
public class Brother : MonoBehaviour {

    public CharacterMovement characterMove;

    public List<AudioClip> hurtSounds = new List<AudioClip>();
    
    public void Hurt()
    {
        string hashedName = AudioManager.GenerateSourceName("hurt");

        int randomSound = UnityEngine.Random.Range(0, hurtSounds.Count - 1);

        AudioManager.audioManager.PushAndPlay(hashedName, hurtSounds[randomSound]);

        AudioManager.audioManager.RemoveSource(hashedName);
    }

    // Use this for initialization
    void Start () {
        characterMove = GetComponent<CharacterMovement>();
	}
}
