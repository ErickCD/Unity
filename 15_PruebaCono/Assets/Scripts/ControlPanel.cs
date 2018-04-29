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
        //get the animator component
        anim = MenuPanel.GetComponent<Animator>();
        anim.enabled = true;
    }

    public void hiddenAndNotHidden(){
        if (isHidden)
        {
            anim.Play("muestraPanel"); 
            isHidden = false;
        }
        else
        {
            isHidden = true; 
            anim.Play("ocultaPanel");
        }
    }
}
