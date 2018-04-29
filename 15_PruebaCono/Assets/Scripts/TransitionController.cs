using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransitionController : MonoBehaviour {

    //public Animator panel;
    //Animator ConoExplodedView
    public Animator ani;
    //GameObject Slider
    public Slider slider;
    //varClas to control the speed 
    private float speedSlider;

    public void ChangeTransition(string nameTrasition){
        switch (nameTrasition) {
                //Para viento normal
            case "vientoB":
                ani.Play("vientoBajo", 0, speedSlider);
                Time.timeScale = 1;
                break;
            case "vientoM":
                ani.Play("vientoMedio", 0, speedSlider);
                Time.timeScale = 1;
                break;
            case "vientoA":
                ani.Play("vientoAlto", 0, speedSlider);
                Time.timeScale = 1;
                break;

            //Para viento a la derecha 
            case "RvientoB":
                ani.Play("Armature|vientoBajoR", 0, speedSlider);
                Time.timeScale = 1;
                break;
            case "RvientoM":
                ani.Play("Armature|vientoMedioR", 0, speedSlider);
                Time.timeScale = 1;
                break;
            case "RvientoA":
                ani.Play("Armature|vientoAltoR", 0, speedSlider);
                Time.timeScale = 1;
                break;

            //Para viento a la izquierda
            case "LvientoB":
                ani.Play("Armature|vientoBajoL", 0, speedSlider);
                Time.timeScale = 1;
                break;
            case "LvientoM":
                ani.Play("Armature|vientoMedioL", 0, speedSlider);
                Time.timeScale = 1;
                break;
            case "LvientoA":
                ani.Play("Armature|vientoAltoL", 0, speedSlider);
                Time.timeScale = 1;
                break;

            //Explosion salir y quieto
            case "salir":
                Application.Quit();
                break;
            case "quieto":
                ani.Play("Quieto", 0, speedSlider);
                Time.timeScale = 1;
                break;
        }
    }

    public void changeScene(int actual)
    {
        if(actual == 0){
            SceneManager.LoadScene(1);
        }else{
            SceneManager.LoadScene(0);
        }
    }

    public void playSlider() {
        Update();
        ani.Play("Armature|Explosion", 0, speedSlider);
        Time.timeScale = 0;
    }

   
    void Update() {
        speedSlider = slider.value;
    }
   
}
