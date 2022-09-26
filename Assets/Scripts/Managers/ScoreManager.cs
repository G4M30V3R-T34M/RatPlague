using Feto;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    public int score { get; set; }

    void Start() {
        score = 0;
    }

    protected override void OnDestroy() {
        base.OnDestroy();
        if (EndGameManager.Instance != null) {
            EndGameManager.Instance.score = score;
        }
    }
}
