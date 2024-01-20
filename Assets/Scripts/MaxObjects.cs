using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxObjects : MonoBehaviour {
    // Creamos una variable estática para almacenar la única instancia
    public static MaxObjects instance;

    [SerializeField] int maxObjects;
    [SerializeField] List<GameObject> currentObjects = new List<GameObject>();
    [SerializeField] bool isHideScene;

    private void Awake() {
        // ----------------------------------------------------------------
        // AQUÍ ES DONDE SE DEFINE EL COMPORTAMIENTO DE LA CLASE SINGLETON
        // Garantizamos que solo exista una instancia del SCManager
        // Si no hay instancias previas se asigna la actual
        // Si hay instancias se destruye la nueva
        if (instance == null) instance = this;
        else { Destroy(gameObject); return; }
        // ----------------------------------------------------------------

        // No destruimos el SceneManager aunque se cambie de escena
        DontDestroyOnLoad(gameObject);
    }

    public int GetNumObjects() {
        return currentObjects.Count;
    }
    public int GetMaxObjects() {
        return maxObjects;
    }
    public int GetFoundObjects() {
        return maxObjects - currentObjects.Count;
    }
    public void AddObjectToList(GameObject obj) {
        currentObjects.Add(obj);
    }
    public void RemoveObjectToList(GameObject obj) {
        currentObjects.Remove(obj);
    }
    public bool HasMaxObjects() {
        if (currentObjects.Count >= maxObjects)
            return true;
        else
            return false;
    }
    public void SetIsHideScene(bool set) {
        isHideScene = set;
    }
    public bool GetIsHideScene() {
        return isHideScene;
    }
}
