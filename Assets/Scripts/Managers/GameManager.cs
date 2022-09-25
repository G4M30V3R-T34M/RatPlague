using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Feto;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameManagerScriptable _settings;
    private int iterations;
    private int totalDays;
    GameStates state;

    public delegate void DayAction();
    public event DayAction dayDelegate, townCrierDelegate;

    private void Start() {
        iterations = 0;

        // TODO: Create Buildings
        BuildingsManager.Instance.CreateHouse(false);
        BuildingsManager.Instance.CreateWareHouse(false);
        BuildingsManager.Instance.CreateBarrak(false);

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
        }
    }

    private IEnumerator Playing() {
        int iterationDay = 0;
        while(iterationDay < _settings.daysPerIteration) {
            yield return new WaitForSeconds(_settings.secondsPerDay);
            dayDelegate();
            yield return null;
            yield return null;
            totalDays += 1;
            HUDManager.Instance.totalDays = totalDays;
            HUDManager.Instance.UpdateGeneralInfoHUD();
            iterationDay += 1;
        }
        UpdateGameState(GameStates.TownCrier);
    }
}
