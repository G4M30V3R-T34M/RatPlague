using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : BaseBuilding
{
    protected enum ShipState { AtPort, Transition, Navigating }
    protected ShipState state = ShipState.Navigating;
    protected ShipScriptable _shipSettings;
    protected int daysInSameState = 0;
    protected int humansOnBoard;
    protected Animator animator;
    const string LEAVE_PORT = "Leave", ARRIVE_PORT = "Arrive";

    protected override void Awake() {
        base.Awake();
        animator = GetComponent<Animator>();

        collider.enabled = false;

        if (_settings is ShipScriptable shipSettings) {
            _shipSettings = shipSettings;
        } else {
            throw new System.Exception($"ShipSettings recieved {_settings.GetType()} instead of ShipSettingsScriptable");
        }
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
        CrierManager.Instance.deathRats += assignedRats;
        assignedRats = 0;
    }

    public void ShipArrivePortEnd() {
        daysInSameState = 0;
        state = ShipState.AtPort;
        GenerateHumansOnBoard();
        collider.enabled = true;
    }

    protected void NavigatingDayAction() {
        if (CheckShipChangeState(_shipSettings.backToPortChancePerDay)) {
            state = ShipState.Transition;
            animator.SetTrigger(ARRIVE_PORT);
            daysInSameState = 0;
        } else {
            daysInSameState++;
        }
    }

    protected void AtPortDayAction() {
        if (CheckShipChangeState(_shipSettings.leavePortChancePerDay)) {
            state = ShipState.Transition;
            collider.enabled = false;
            animator.SetTrigger(LEAVE_PORT);
        } else {
            daysInSameState++;
        }
    }

    protected void CheckHumansInfected() {
        int humansInfected = 0;
        for (int i = 0; i < assignedRats; i++) {
            if (Random.Range(0.0f, 1.0f) < _shipSettings.humansKilledChance) {
                humansInfected++;
            }
        }
        ScoreManager.Instance.score += humansInfected;
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
        humansOnBoard = Random.Range(_shipSettings.minHumansOnBoard, _shipSettings.maxHumansOnBoard);
    }

}
