using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeAway : MonoBehaviour {

    private DigitalCountDown countdownTimer;
    private Text textUI;
    private int fadeDuration = 5;
    private bool fading = false;

	// Use this for initialization
	void Start () {
        textUI = GetComponent<Text>();
        countdownTimer = GetComponent<DigitalCountDown>();
        StartFading(fadeDuration);
	}
	
	// Update is called once per frame
	void Update () {
        if (fading) {
            float alphaRemaining = countdownTimer.CountDownTimerSecondsremaining();
            print(alphaRemaining);
            Color c = textUI.material.color;
            c.a = alphaRemaining;
            textUI.material.color = c;

            if (alphaRemaining < 0.1)
                fading = false;
        }
	}

    public void StartFading(int timertotal) {
        countdownTimer.CountdownTimerReset(timertotal);
        fading = true;
    }
}
