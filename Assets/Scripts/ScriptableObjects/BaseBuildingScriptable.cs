using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BaseIconScriptable", menuName = "Scriptables/BaseIconScriptable", order = 2)]
public class BaseBuildingScriptable : ScriptableObject
{
    public Color ColorOnMouseEnter;

    [Header("Rats Info")]
    public int maxRats;
    [Range(0.0f, 1.0f)] public float ratsKilledChance;

    [Header("Food Info")]
    public int maxFood;
    public int minFoodGenerated;
    public int maxFoodGenerated;
    [Range(0.0f, 10.0f)] public float streetFoodGenerationChance;

    [Header("Humans Info")]
    [Range(0.0f, 5.0f)] public float humansKilledChance;

    [Header("Structure Info")]
    [Range(0.0f, 1.0f)] public float destructionChance;
    [Range(0.0f, 1.0f)] public float ratsKilledOnDestructionChance;
} 