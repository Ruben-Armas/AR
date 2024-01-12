using TMPro;
using UnityEngine;

public class CollectibleObject : MonoBehaviour {
    [SerializeField] int score;

    private void OnMouseEnter() {
        score++;
        GameObject.Find("Score").GetComponent<TMP_Text>().text = "Score: " + score.ToString();
    }
}
