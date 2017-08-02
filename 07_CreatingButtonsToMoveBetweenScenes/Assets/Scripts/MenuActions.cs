using System.Collections;
using UnityEngine;

public class MenuActions : MonoBehaviour {

    public void MENU_ACTION_GotoPage(string sceneName){
        Application.LoadLevel(sceneName);
        //SceneManager.LoadScene(sceneName);
    }
}
