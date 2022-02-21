using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    private TimeAfterTime timer;

    public bool start;

    public int initialSeconds = 120;
    public int timeLeft;

    public delegate void NoTimeLeft();
    //Called when the timer comes out.
    public event NoTimeLeft noTimeLeft;

    public delegate void TimerUpdate();
    //Called when the timer comes out.
    public event TimerUpdate timerUpdate;

    // Use this for initialization
    void Start()
    {
        timeLeft = initialSeconds;
        timer = new TimeAfterTime();
        start = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            if (timeLeft == initialSeconds)
            {
                foreach (Brother b in GameManager.gameManager.brothers)
                {
                    b.characterMove.frozen = false;
                }
            }

            if (timer.GetTimeElapsed(1.0f))
            {
                timeLeft -= 1;
                timerUpdate();
            }



        }

        timer.time += Time.deltaTime;

        if (timeLeft == 0)
        {
            start = false;
            noTimeLeft();
        }

    }

}
