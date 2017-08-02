using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DigitalCountDown : MonoBehaviour {

    private Text textClock;

    private float countDownTimerDuration;
    private float countDownTimerStartTime;

	// Use this for initialization
	void Start () {
        textClock = GetComponent<Text>();
        CountdownTimerReset(30);
	}
	
    /*
	// Update is called once per frame
	void Update () {
		//default - timer finished
        string timerMessange = "Count has finished";
        int timeLeft = (int)CountDownTimerSecondsremaining();

        if (timeLeft > 0){
            timerMessange = "Countdown seconds remaining = " + LeadingZero(timeLeft);
            textClock.text = timerMessange;
        }
	}

    */
    public void CountdownTimerReset(float delayInSeconds) {
        countDownTimerDuration = delayInSeconds;
        countDownTimerStartTime = Time.time;
    }

    public float CountDownTimerSecondsremaining() {
        float elapsedSeconds = Time.time - countDownTimerStartTime;
        float timeLeft = countDownTimerDuration - elapsedSeconds;
        return timeLeft;
    }

    private string LeadingZero(int n){
        return n.ToString().PadLeft(2, '0');
    }
}
