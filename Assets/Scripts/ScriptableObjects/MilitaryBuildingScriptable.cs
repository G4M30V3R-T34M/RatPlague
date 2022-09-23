using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MilitaryBuildingScriptable", menuName = "Scriptables/MilitaryBuildingScriptable", order = 3)]
public class MilitaryBuildingScriptable : BaseBuildingScriptable
{
    [Header("Military Power")]
    public int ratsNeededForDistraction;
}
