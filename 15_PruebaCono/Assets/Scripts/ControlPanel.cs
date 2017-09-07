using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanel : MonoBehaviour {

    public Animator ButtonPanel;

    public void animacionPanel()
    {
        print("Este es el hidden: " + ButtonPanel.GetBool("hidden"));
    }
}
