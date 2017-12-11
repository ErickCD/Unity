using System.Collections;
using UnityEngine;

using UnityEngine.UI;
using System;

public class ClockDigital : MonoBehaviour {

    private Text textClock;

	//Se inicializa el código
	void Start () {
        textClock = GetComponent<Text>();
	}
	
	// Se actualiza una vez por frame
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
