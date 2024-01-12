using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCSelectorBtn : MonoBehaviour {
    public void HideObjects() {
        MaxObjects.instance.SetIsHideScene(true);
        SCManager.instance.LoadScene("ARGame");
    }
    public void SeekObjects() {
        MaxObjects.instance.SetIsHideScene(false);
        SCManager.instance.LoadScene("ARGame");
        //SCManager.instance.LoadSceneAdditive("Score");
    }

    public void MainMenu() {
        SCManager.instance.LoadScene("MainTitle");
    }
    public void Surrender() {
        // Resetea todos los objetos antes de volver
        DestroyObjectsByTag.instance.DestroyObjectsTag("Key");
        SCManager.instance.LoadScene("MainTitle");
    }

    public void Exit() {
        Application.Quit();
    }
}
