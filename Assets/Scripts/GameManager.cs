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

    private void Start() {
        iterations = 0;
        UpdateGameState(GameStates.Play);
    }

    public void UpdateGameState(GameStates newState) {
        state = newState;
        switch (state) {
            case GameStates.Play:
                if(iterations < _settings.totalIterations) {
                    StartCoroutine(Playing());
                } else {
                    UpdateGameState(GameStates.GameOver);
                }
                break;
            case GameStates.Crier:
                // TODO perform crier action
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
            // TODO perform day action
            iterationDay += 1;
        }
        UpdateGameState(GameStates.Crier);
    }
}
