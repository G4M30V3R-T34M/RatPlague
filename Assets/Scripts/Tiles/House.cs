using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : BaseBuilding
{
    protected override void DayAction() {
        InfectHumans();
        GenerateStreetFood();
        GenerateFood();
        KillRats(_settings.ratsKilledChance);
        FeedRats();
    }

    protected override void TownCrierAction() {
        CheckBuildingDestruction();
    }

    protected void FeedRats() {
        currentFood -= assignedRats;
        if (currentFood < 0) {
            assignedRats += currentFood; // Kill rats that couldn't eat
            CrierManager.Instance.deathRats += -currentFood; // Count death rats
            currentFood = 0;
        }
    }

    protected void GenerateFood() {
        int food = Random.Range(_settings.minFoodGenerated, _settings.maxFoodGenerated);
        currentFood += food;
        currentFood = Mathf.Clamp(currentFood, 0, _settings.maxFood);
    }

    protected void InfectHumans() {
        // TODO: MISSING SCORE MANAGER
        // TODO: ADD SCORE TO CRIER MANAGER
    }

    protected void GenerateStreetFood() {
        int generatedFood = 0;
        for (int i = 0; i < assignedRats; i++) {
            if (Random.Range(0.0f, 1.0f) < _settings.streetFoodGenerationChance ) {
                generatedFood++;
            }
        }
        Street.Instance.food += generatedFood;
    }

    protected void KillRats(float killChance) {
        int killedRats = 0;
        for (int i = 0; i < assignedRats; i++) {
            if (Random.Range(0.0f, 1.0f) < killChance ) {
                killedRats++;
            }
        }
        CrierManager.Instance.deathRats += killedRats;
        assignedRats -= killedRats;
    }

    protected void CheckBuildingDestruction() {
        float maxRatio = _settings.destructionChance * GetRatOccupationRatio();
        if (Random.Range(0.0f, 1.0f) < maxRatio) {
            // TODO: How do we destroy Building

            KillRats(_settings.ratsKilledOnDestructionChance);
            Street.Instance.Assign(assignedRats);
            assignedRats = 0;
        }
    }
}
