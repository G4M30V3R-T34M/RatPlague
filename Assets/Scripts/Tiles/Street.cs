using Feto;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Street : Singleton<Street>
{
    [SerializeField] StreetScriptable _settings;
    public int food {
        get { return availableFood + generatedFood; }
        set { generatedFood = value; }
    }
    protected int availableFood;
    protected int generatedFood;
    public int rats { get; private set; }

    private bool executedStart = false;

    private void Start() {
        rats = _settings.startingRats;
        food = _settings.startingFood;
        availableFood = food;
        executedStart = true;
        OnEnable();
        // Update HUD
        HUDManager.Instance.totalRats = rats;
        HUDManager.Instance.totalFood = food;
        HUDManager.Instance.UpdateGeneralInfoHUD();
    }

    protected void OnEnable() {
        if (executedStart) {
            GameManager.Instance.dayDelegate += DayAction;
            GameManager.Instance.townCrierDelegate += TownCrierAction;
        }
    }

    protected void OnDisable() {
        if (GameManager.Instance != null) {
            GameManager.Instance.dayDelegate -= DayAction;
            GameManager.Instance.townCrierDelegate -= TownCrierAction;
        }
    }

    protected void DayAction() {
        FeedRats();
        ReproduceRats();
        StartCoroutine(UpdateAvailableFood());
    }

    protected void FeedRats() {
        availableFood -= rats;
        if (availableFood < 0) {
            rats += availableFood; // Kill rats that couldn't eat
            availableFood = 0;
        }
    }

    protected void ReproduceRats() {
        int newRats = 0;
        for (int i = 0; i < rats; i++) {
            if (Random.Range(0.0f, 1.0f) < _settings.ratReproductionRate) {
                newRats++;
            }
        }
        CrierManager.Instance.bornRats += newRats;
        rats += newRats;
    }

    protected void TownCrierAction() {
        CrierManager.Instance.currentFood = food;
    }

    IEnumerator UpdateAvailableFood() {
        yield return null;
        availableFood += generatedFood;
        generatedFood = 0;
        HUDManager.Instance.totalFood = food;
    }

    public bool HasAvaibleRats(int desiredRats) {
        return rats >= desiredRats;
    }

    public void Assign(int ratsToAssign) {
        rats += ratsToAssign;
    }

    public void Unassign(int ratsToUnassign) {
        rats -= ratsToUnassign;
    }

}
