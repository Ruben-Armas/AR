using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class OnPressControl : MonoBehaviour {
    /// <summary>
    /// The input touch control.
    /// </summary>
    TouchControls controls;

    [SerializeField] int currentObjects = 0;

    private void Awake() {
        controls = new TouchControls();
        // If there is touch input being performed. call the OnPress function.
        controls.control.touch.performed += ctx => {
            if (ctx.control.device is Pointer device) {
                OnPress(device.position.ReadValue());
            }
        };
    }

    private void OnEnable() {
        controls.control.Enable();
    }
    private void OnDisable() {
        controls.control.Disable();
    }

    void OnPress(Vector3 position) {
        Debug.Log("Press");
        // Solo si está en la escena de Seek/Buscar Objetos
        if (!MaxObjects.instance.GetIsHideScene()) {
            // Rayo que comprueba si ha pulsado un Objeto "Key"
            // Realiza un raycast desde la posición del toque en la dirección de la cámara
            Ray ray = Camera.main.ScreenPointToRay(position);
            RaycastHit hit;

            // Ajusta la distancia máxima según tu escenario
            float maxRaycastDistance = 100f;

            if (Physics.Raycast(ray, out hit, maxRaycastDistance)) {
                // Imprime información para depuración
                //Debug.Log("Presionado en posición: " + position);
                Debug.Log("Golpeó objeto con nombre: " + hit.collider.gameObject.name);

                // Comprueba si el objeto golpeado tiene la etiqueta "Key"
                if (hit.collider.CompareTag("Key")) {
                    Debug.Log("Presionado un objeto con la etiqueta 'Key'");

                    // Destruye el objeto "key"
                    Destroy(hit.collider.gameObject);

                    // Aumenta el contador de encontrados
                    currentObjects++;

                    // Elimina el objeto de la lista de Objetos
                    MaxObjects.instance.RemoveObjectToList(hit.collider.gameObject);

                    // Si los tiene todos ir a Escena Ganador
                    if (currentObjects >= MaxObjects.instance.GetMaxObjects() /*|| MaxObjects.instance.GetNumObjects() == 0*/)
                        SCManager.instance.LoadScene("WinScene");
                }
            }
        }

        
        /*
        // Check if the raycast hit any trackables.
        if (aRRaycastManager.Raycast(position, hits, TrackableType.PlaneWithinPolygon)) {
            // Raycast hits are sorted by distance, so the first hit means the closest.
            var hitPose = hits[0].pose;


            if (MaxObjects.instance.GetIsHideScene()) {
                // Instantiated the prefab.
                spawnedObject = Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
                //Guarda el objeto en la lista de objetos Singleton
                MaxObjects.instance.AddObjectToList(spawnedObject);

                // To make the spawned object always look at the camera. Delete if not needed.
                Vector3 lookPos = Camera.main.transform.position - spawnedObject.transform.position;
                lookPos.y = 0;
                spawnedObject.transform.rotation = Quaternion.LookRotation(lookPos);
            }
        }*/
    }
}
