using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Feto;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameManagerScriptable _settings;
    private int iterations;
    GameStates state;

    public delegate void DayAction();
    public event DayAction day, townCrierDelegate;

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
                }
                GameOverManager.Instance.EndGame(GameOverCondition.Quarantine);
                break;
            case GameStates.Pause:
                // TODO perform pause action
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
            day.Invoke();
            iterationDay += 1;
        }
        UpdateGameState(GameStates.TownCrier);
    }
}
