using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCSelectorBtn : MonoBehaviour {
    public void PlayGame() {
        SCManager.instance.LoadScene("ARGame");
    }

    public void MainMenu() {
        SCManager.instance.LoadScene("MainTitle");
    }

    public void Exit() {
        Application.Quit();
    }
}
