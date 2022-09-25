using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryBuilding : House
{
    public new MilitaryBuildingScriptable _settings;
    protected override void DayAction() {
        CheckMilitaryPower();
        base.DayAction();
    }

    protected void CheckMilitaryPower() {
        int notDistracted = _settings.ratsNeededForDistraction - assignedRats;
        if (notDistracted > 0) {
            CrierManager.Instance.deathRats += notDistracted;
            Street.Instance.Unassign(notDistracted);
        }
    }

}
