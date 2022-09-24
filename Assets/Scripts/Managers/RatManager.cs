using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Feto;

public class RatManager : Singleton<RatManager>
{
    Street street;
    List<BaseBuilding> buildings;

    protected override void Awake() {
        base.Awake();
        street = FindObjectOfType<Street>();
    }

    protected void Start() {
        buildings = new List<BaseBuilding>();
        GameManager.Instance.day += RatCheck;
    }

    protected override void OnDestroy() {
        GameManager.Instance.day -= RatCheck;
        base.OnDestroy();
    }

    public void AddBuilding(BaseBuilding building) {
        buildings.Add(building);
    }
    
    public void RemoveBuilding(BaseBuilding building) {
        buildings.Remove(building);
    }

    protected void RatCheck() {
        StartCoroutine(RatCheckCoroutine());
    }

    IEnumerator RatCheckCoroutine() {
        yield return null; // Be sure all day actions have happened
        int rats = 0;

        rats += street.rats;

        for (int i = 0; i < buildings.Count; i++) {
            rats += buildings[i].assignedRats;
        }

        if (rats <= 0) {
            GameOverManager.Instance.EndGame(GameOverCondition.NoRats);
        } else if (rats >= 100) {
            GameOverManager.Instance.EndGame(GameOverCondition.TooManyRats);
        }
    }
}
