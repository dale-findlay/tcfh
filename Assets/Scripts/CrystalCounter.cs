using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalCounter : MonoBehaviour {

    public int crystalCount = 0;
    public Text gameText;
    public GameObject winBox;

    public int winCrystalAmount = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        gameText.text = crystalCount.ToString();

        if(crystalCount == winCrystalAmount)
        {
            crystalCount = 0;

            winBox.SetActive(true);
        }

    }
}
