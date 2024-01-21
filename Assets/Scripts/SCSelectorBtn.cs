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
        SCManager.instance.LoadScene("ARGame2");
        //SCManager.instance.LoadSceneAdditive("Score");
    }

    public void MainMenu() {
        SCManager.instance.LoadScene("MainTitle");
    }
    public void Surrender() {
        // Resetea todos los objetos antes de volver
        //DestroyObjectsByTag.instance.DestroyObjectsTag("Key");
        DestroyObjectsTag("Key");
        SCManager.instance.LoadScene("MainTitle");
    }

    public void Exit() {
        Application.Quit();
    }


    public void DestroyObjectsTag(string objectTag) {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(objectTag);

        if (objs.Length > 1) {
            Debug.Log("Clear: " + objs.Length + ", " + MaxObjects.instance.GetNumObjects());

            foreach (GameObject obj in objs) {
                Destroy(obj);
            }

            //Vacía la lista de objetos
            MaxObjects.instance.ClearObjectsList();
        }
        else {
            Debug.Log("else: " + objs.Length + ", " + GameObject.FindGameObjectWithTag("Key"));
        }
    }
}
