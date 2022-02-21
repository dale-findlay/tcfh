using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Timer))]
public class TimerText : MonoBehaviour {

    private Timer timer;

	// Use this for initialization
	void Start () {
        timer = GetComponent<Timer>();
        timer.timerUpdate += UpdateText;
    }
	
    void UpdateText()
    {
        GetComponent<UnityEngine.UI.Text>().text = timer.timeLeft.ToString();
    }
}
