using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadBestScores : MonoBehaviour
{
    [SerializeField] bool LoadOnStart = false;
    [SerializeField] string namePlaceholder;
    [SerializeField] int scorePlaceholder;

    [SerializeField] TextMeshProUGUI[] bestScores;

    private void Start() {
        if (LoadOnStart) {
            Load();
        }
    }

    public void Load() {
        for (int i = 0; i < bestScores.Length; i++) {
            LoadBestScore(bestScores[i], i + 1);
        }
    }

    protected void LoadBestScore(TextMeshProUGUI textmesh, int position) {
        textmesh.SetText(
            string.Format("{0} - {1:00000}",
            BestScores.GetName(position, namePlaceholder),
            BestScores.GetScore(position, scorePlaceholder))
            );
    }
}
