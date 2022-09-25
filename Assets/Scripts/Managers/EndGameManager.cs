using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Feto;

public class EndGameManager : SingletonPersistent<EndGameManager>
{
    public GameOverCondition endGameCause;
    public int score { get; set; }

    public void EndGame(GameOverCondition cause) {
        endGameCause = cause;
        SceneManager.ChangeScene(Scenes.GameOver);
    }
}
