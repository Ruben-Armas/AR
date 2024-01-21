using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOnMouseEnter : MonoBehaviour {
    private void OnMouseEnter() {
        if (PlayerPrefs.GetInt("mode") == 1) return;
        //GameManager.instance.gameObjects.Remove(this.gameObject);
        //GameManager.instance.AddScore();
        Destroy(this.gameObject);
    }
}
