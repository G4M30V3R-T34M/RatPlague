using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Feto;

public class GameOverManager : SingletonPersistent<GameOverManager>
{
    [SerializeField] string noRatsEnd;
    [SerializeField] string tooManyRatsEnd;
    [SerializeField] string quarantineEnd;

    GameOverCondition endGameCause;

    public void EndGame(GameOverCondition cause) {
        endGameCause = cause;
        SceneManager.ChangeScene(Scenes.GameOver);
    }
}
