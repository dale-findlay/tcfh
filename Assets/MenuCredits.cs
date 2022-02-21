using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCredits : MonoBehaviour {

    public GameObject creditsMenu;

    public void OnClick()
    {
        if(creditsMenu.activeInHierarchy)
        {
            creditsMenu.SetActive(false);
        }
        else
        {
            creditsMenu.SetActive(true);
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
