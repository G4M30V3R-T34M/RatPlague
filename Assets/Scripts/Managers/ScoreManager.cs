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
}
