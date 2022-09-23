using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShipScriptable", menuName = "Scriptables/ShipScriptable", order = 4)]
public class ShipScriptable : BaseBuildingScriptable
{
    [Header("Ship Info")]
    public float backToPortChancePerDay;
    public float leavePortChancePerDay;
    public int minHumansOnBoard;
    public int maxHumansOnBoard;
}
