using UnityEngine;

public class DestroyObjectsByTag : MonoBehaviour {
    [SerializeField] string objectTag;

    public void DestroyObjectsTag(string objectTag) {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(objectTag);

        if (objs.Length > 1) {
            Debug.Log("Clear: " + objs.Length + ", " + MaxObjects.instance.GetNumObjects());

            /*foreach (GameObject obj in objs) {
                Destroy(obj);
            }

            //Vacía la lista de objetos
            MaxObjects.instance.ClearObjectsList();*/
        }
        else {
            Debug.Log("else: " + objs.Length + ", " + GameObject.FindGameObjectWithTag("Key"));
        }
    }
}
