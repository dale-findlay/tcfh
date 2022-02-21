using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager;

    public List<Brother> brothers = new List<Brother>();
    public CrystalCounter crystalCount;
    public Timer timer;

    public GameObject gameOverMenu;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        gameManager = this;

    }

    // Use this for initialization
    void Start () {
        timer.noTimeLeft += OpenGameOver;
	}

    void OpenGameOver()
    {
        foreach(Brother b in brothers)
        {
            b.characterMove.frozen = true;
        }

        gameOverMenu.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
