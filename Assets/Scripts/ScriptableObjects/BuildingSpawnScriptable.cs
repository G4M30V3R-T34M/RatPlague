using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingSpawnScriptable", menuName = "Scriptables/BuildingSpawnScriptable", order = 5)]
public class BuildingSpawnScriptable : ScriptableObject
{
    [Header("Spawn Position")]
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float xDist;
    public float yDist;
}
