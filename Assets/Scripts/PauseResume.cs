using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResume : MonoBehaviour {

    public void OnClick()
    {
        foreach(Brother b in GameManager.gameManager.brothers)
        {
            b.characterMove.frozen = false;
        }

        transform.parent.gameObject.SetActive(false);
        GameManager.gameManager.timer.start = true;

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
