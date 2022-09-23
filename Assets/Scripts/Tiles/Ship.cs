using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : BaseBuilding
{
    protected enum ShipState { AtPort, Transition, Navigating }
    protected ShipState state = ShipState.Navigating;
    protected new ShipScriptable _settings;
    protected int daysInSameState = 0;
    protected int humansOnBoard;

    protected override void Awake() {
        base.Awake();
        collider.enabled = false;
    }

    protected override void DayAction() {
        if (state == ShipState.Navigating) {
            NavigatingDayAction();
        } else if (state == ShipState.AtPort){
            AtPortDayAction();
        }
    }

    protected override void TownCrierAction() { /* No Actions here */ }

    public void ShipLeavePortEnd() {
        daysInSameState = 0;
        state = ShipState.Navigating;
        CheckHumansInfected();
        assignedRats = 0;
    }

    public void ShipArrivePortEnd() {
        daysInSameState = 0;
        state = ShipState.AtPort;
        GenerateHumansOnBoard();
        collider.enabled = true;
    }

    protected void NavigatingDayAction() {
        if (CheckShipChangeState(_settings.backToPortChancePerDay)) {
            state = ShipState.Transition;
            // TODO: Start BackToPortAnimation
            daysInSameState = 0;

        } else {
            daysInSameState++;
        }
    }

    protected void AtPortDayAction() {
        if (CheckShipChangeState(_settings.leavePortChancePerDay)) {
            state = ShipState.Transition;
            collider.enabled = false;
            // TODO: Start LeavePortAnimation
        } else {
            daysInSameState++;
        }
    }

    protected void CheckHumansInfected() {
        int humansKilled = 0;
        for (int i = 0; i < assignedRats; i++) {
            if (Random.Range(0.0f, 1.0f) < _settings.humansKilledChance) {
                humansKilled++;
            }
        }
        // TODO: ScoreManager
    }

    protected bool CheckShipChangeState(float chance) {
        int i = 0;
        bool changeState = false;

        while (i++ < daysInSameState && !changeState) {
            changeState = Random.Range(0.0f, 1.0f) < chance;
        }

        return changeState;
    }

    protected void GenerateHumansOnBoard() {
        humansOnBoard = Random.Range(_settings.minHumansOnBoard, _settings.maxHumansOnBoard);
    }

}