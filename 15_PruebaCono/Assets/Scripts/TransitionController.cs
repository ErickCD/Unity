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

    private void NecesarioParaCambio() {
        //Para regresar a un estado quieto
        ani.SetBool("Quieto", true);
        //Viento normal
        ani.SetBool("vientoB", false);
        ani.SetBool("vientoM", false);
        ani.SetBool("vientoA", false);
        //Viento a la izquierda
        ani.SetBool("vientoBL", false);
        ani.SetBool("vientoML", false);
        ani.SetBool("vientoAL", false);
        //Viento a la derecha
        ani.SetBool("vientoBR", false);
        ani.SetBool("vientoMR", false);
        ani.SetBool("vientoAR", false);

        ani.SetBool("explosion", false);
    }

    private void cambioSlider() {
        slider.value = 0;
    }

    public void ChangeTransition(string nameTrasition){
        //Thread.Sleep(500);
        switch (nameTrasition) {
                //Para viento normal
            case "vientoB":
                NecesarioParaCambio();
                cambioSlider();
                ani.SetBool("vientoB", true);
                ani.SetBool("Quieto", false);
                break;
            case "vientoM":
                NecesarioParaCambio();
                cambioSlider();
                ani.SetBool("vientoM", true);
                ani.SetBool("Quieto", false);
                break;
            case "vientoA":
                NecesarioParaCambio();
                cambioSlider();
                ani.SetBool("vientoA", true);
                ani.SetBool("Quieto", false);
                break;
            //Para viento a la derecha 
            case "RvientoB":
                NecesarioParaCambio();
                cambioSlider();
                ani.SetBool("vientoBR", true);
                ani.SetBool("Quieto", false);
                break;
            case "RvientoM":
                NecesarioParaCambio();
                cambioSlider();
                ani.SetBool("vientoMR", true);
                ani.SetBool("Quieto", false);
                break;
            case "RvientoA":
                NecesarioParaCambio();
                cambioSlider();
                ani.SetBool("vientoAR", true);
                ani.SetBool("Quieto", false);
                break;
            //Para viento a la izquierda
            case "LvientoB":
                NecesarioParaCambio();
                cambioSlider();
                ani.SetBool("vientoBL", true);
                ani.SetBool("Quieto", false);
                break;
            case "LvientoM":
                NecesarioParaCambio();
                cambioSlider();
                ani.SetBool("Quieto", false);
                ani.SetBool("vientoML", true);
                break;
            case "LvientoA":
                NecesarioParaCambio();
                cambioSlider();
                ani.SetBool("Quieto", false);
                ani.SetBool("vientoAL", true);
                break;
            case "exploded":
                NecesarioParaCambio();
                ani.SetBool("Quieto", false);
                ani.SetBool("explosion", true);
                break;
            case "salir":
                print("Entro a la parte de salir");
                //NecesarioParaCambio();
                //ani.SetBool("Quieto", false);
                //ani.SetBool("salir", true);
                Application.Quit();
                break;
            case "quieto":
                NecesarioParaCambio();
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

    void Update() {
        speedSlider = slider.value;
        //Solo una impresión
        if (speedSlider > 0.1 || speedSlider < -0.1)
        {
            print(speedSlider);
            //ChangeTransition("quieto");
            ChangeTransition("exploded");
            ani.SetFloat("speed", speedSlider);
        }
    }
}
