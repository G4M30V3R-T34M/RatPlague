using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StreetScriptable", menuName = "Scriptables/StreetScriptable", order = 4)]
public class StreetScriptable : ScriptableObject
{
    public int startingRats;
    public int startingFood;

    [Range(0.0f, 1.0f)] public float ratReproductionRate;
}
