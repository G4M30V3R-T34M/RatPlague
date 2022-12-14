using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Feto;

public class RatManager : Singleton<RatManager>
{
    List<BaseBuilding> buildings;
    Coroutine ratCheckCoroutine;

    protected void Start() {
        buildings = new List<BaseBuilding>();
        GameManager.Instance.dayDelegate += RatCheck;
    }

    protected override void OnDestroy() {
        base.OnDestroy();
        if (ratCheckCoroutine != null) {
            StopCoroutine(ratCheckCoroutine);
        }
        if (GameManager.Instance != null) {
            GameManager.Instance.dayDelegate -= RatCheck;
        }
    }

    public void AddBuilding(BaseBuilding building) {
        buildings.Add(building);
    }
    
    public void RemoveBuilding(BaseBuilding building) {
        if (buildings != null) {
            buildings.Remove(building);
        }
    }

    protected void RatCheck() {
        ratCheckCoroutine = StartCoroutine(RatCheckCoroutine());
    }

    IEnumerator RatCheckCoroutine() {
        yield return null; // Be sure all day actions have happened
        int rats = 0;

        if (Street.Instance != null) {
            rats += Street.Instance.rats;
        }

        for (int i = 0; i < buildings.Count; i++) {
            rats += buildings[i].assignedRats;
        }

        CrierManager.Instance.currentRats = rats;
        HUDManager.Instance.totalRats = rats;

        if (rats <= 0) {
            EndGameManager.Instance.EndGame(GameOverCondition.NoRats);
        } else if (rats >= 100) {
            EndGameManager.Instance.EndGame(GameOverCondition.TooManyRats);
        }
    }
}
