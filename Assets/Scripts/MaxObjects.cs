using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxObjects : MonoBehaviour {
    // Creamos una variable estática para almacenar la única instancia
    public static MaxObjects instance;

    [SerializeField] int maxObjects;
    List<GameObject> objects = new List<GameObject>();
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
        return objects.Count;
    }
    public void AddObjectToList(GameObject obj) {
        objects.Add(obj);
    }
    public bool HasMaxObjects() {
        if (objects.Count >= maxObjects)
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
