using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryBuilding : House
{
    protected MilitaryBuildingScriptable _militarySettings;

    protected override void Awake() {
        base.Awake();

        if (_settings is MilitaryBuildingScriptable militarySettings) {
            _militarySettings = militarySettings;
        } else {
            throw new System.Exception($"ShipSettings recieved {_settings.GetType()} instead of ShipSettingsScriptable");
        }
    }
    protected override void DayAction() {
        CheckMilitaryPower();
        base.DayAction();
    }

    protected void CheckMilitaryPower() {
        int notDistracted = _militarySettings.ratsNeededForDistraction - assignedRats;
        if (notDistracted > 0) {
            CrierManager.Instance.deathRats += notDistracted;
            Street.Instance.Unassign(notDistracted);
        }
    }

}
