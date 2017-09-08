using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class controlPanel : MonoBehaviour {
    //Reference to scrollAndButtonsPanel
    public GameObject MenuPanel;
    //AnimationReference
    private Animator anim;
    //Variable to determine if is hidden or not do.
    private bool isHidden = false;

    void Start(){
        //unpause the game on start
        //Time.timeScale = 1;
        //get the animator component
        anim = MenuPanel.GetComponent<Animator>();
        //disable it on start to stop it from playing the default animation
        anim.enabled = true;
    }

    public void hiddenAndNotHidden(){
        if (isHidden)
        {
            //anim.enabled = true; 
            anim.Play("muestraPanel"); 
            isHidden = false;
            Time.timeScale = 1;
        }
        else
        {
            isHidden = true; 
            anim.Play("ocultaPanel"); 
            Time.timeScale = 1;
        }
    }
}
