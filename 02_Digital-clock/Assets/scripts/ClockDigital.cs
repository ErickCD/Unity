using System.Collections;
using UnityEngine;

using UnityEngine.UI;
using System;

public class ClockDigital : MonoBehaviour {

    private Text textClock;

	// Use this for initialization
	void Start () {
        textClock = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        DateTime time = DateTime.Now;
        String hour = LeadingZero(time.Hour);
        String minute = LeadingZero(time.Minute);
        String second = LeadingZero(time.Second);

        textClock.text = "La hora es: "+hour + ":" + minute + ":" + second;
	}

    String LeadingZero(int n){
        return n.ToString().PadLeft(2, '0');
    }
}
