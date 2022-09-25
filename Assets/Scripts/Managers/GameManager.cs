using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Feto;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameManagerScriptable _settings;
    private int iterations;
    GameStates state;

    public delegate void DayAction();
    public event DayAction dayDelegate, townCrierDelegate;

    private void Start() {
        iterations = 0;
        UpdateGameState(GameStates.Play);
    }

    public void UpdateGameState(GameStates newState) {
        state = newState;
        switch (state) {
            case GameStates.Play:
                CrierManager.Instance.SetUpTownCrier();
                StartCoroutine(Playing());
                break;
            case GameStates.TownCrier:
                if (townCrierDelegate != null) { townCrierDelegate(); };
                iterations++;
                if (iterations < _settings.totalIterations) {
                    CrierManager.Instance.DisplayInfo();
                } else {
                    EndGameManager.Instance.EndGame(GameOverCondition.Quarantine);
                }
                break;
            case GameStates.CrierAssign:
                // TODO perform pause action
                // TMP bypass due crier assign not implemented yet
                UpdateGameState(GameStates.Play);
                break;
            case GameStates.GameOver:
                // TODO perform gameOver action
                break;
        }
    }

    private IEnumerator Playing() {
        int iterationDay = 0;
        while(iterationDay < _settings.daysPerIteration) {
            yield return new WaitForSeconds(_settings.secondsPerDay);
            dayDelegate();
            yield return null;
            yield return null;
            HUDManager.Instance.UpdateGeneralInfoHUD();
            iterationDay += 1;
        }
        UpdateGameState(GameStates.TownCrier);
    }
}
