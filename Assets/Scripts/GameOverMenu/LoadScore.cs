using UnityEngine;
using TMPro;

public class LoadScore : MonoBehaviour
{
    TextMeshProUGUI text;

    private void Awake() {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Start() {
        text.SetText("{0:00000}", EndGameManager.Instance.score);
    }
}
