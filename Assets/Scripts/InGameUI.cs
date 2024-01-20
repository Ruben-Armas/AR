using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameUI : MonoBehaviour {
    public Canvas canvas;

    public TextMeshProUGUI total;
    public TextMeshProUGUI found;

    private void Start() {
        // Muestra el cavas solo en la escena de Seek/Buscar Objetos
        canvas.enabled = !MaxObjects.instance.GetIsHideScene();
    }

    void Update() {
        //lives.text = $"Lives: <color=#00e600><b>{gameManager.currentLives}</b>";
        //ammo.text = $"Ammo: <color=#e60000><b>{gameManager.currentAmmo}</b>";
        total.text = $"Total: <color=#00e600><b>{MaxObjects.instance.GetMaxObjects()}</b>";
        found.text = $"Found: <color=#e60000><b>{MaxObjects.instance.GetFoundObjects()}</b>";
    }    
}