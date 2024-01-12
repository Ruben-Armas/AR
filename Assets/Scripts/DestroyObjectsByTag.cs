using UnityEngine;

public class DestroyObjectsByTag : MonoBehaviour {
    // Creamos una variable estática para almacenar la única instancia
    public static DestroyObjectsByTag instance;

    [SerializeField] string objectTag;

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


    public void DestroyObjectsTag(string objectTag) {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(objectTag);

        if (objs.Length > 1) {
            Destroy(this.gameObject);
        }
    }
}
