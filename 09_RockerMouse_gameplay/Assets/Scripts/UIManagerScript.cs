using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerScript : MonoBehaviour {

    public Animator dialog;
    public Animator startButton;
    public Animator settingsButton;

    public void StartGame() {
        SceneManager.LoadScene("RocketMouse");
    }

    public void OpenSettings() {
        startButton.SetBool("isHidden", true);
        settingsButton.SetBool("isHidden", true);

        //Is add sometime left.
        dialog.SetBool("isHidden", false);
    }

    public void CloseSettings() {
        startButton.SetBool("isHidden", false);
        settingsButton.SetBool("isHidden", false);
        dialog.SetBool("isHidden", true);
    }
}
