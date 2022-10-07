using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "BaseBuildingScriptable", menuName = "Scriptables/BaseBuildingScriptable", order = 2)]
public class BaseBuildingScriptable : ScriptableObject
{
    [Header("General Info")]
    public Buildings buildingName;
    public LocalizedString buildingDescription;

    [Header("Rats Info")]
    public int maxRats;
    [Range(0.0f, 1.0f)] public float ratsKilledChance;

    [Header("Food Info")]
    public int startingFood;
    public int maxFood;
    public int minFoodGenerated;
    public int maxFoodGenerated;
    [Range(0.0f, 10.0f)] public float streetFoodGenerationChance;

    [Header("Humans Info")]
    [Range(0.0f, 5.0f)] public float humansKilledChance;

    [Header("Structure Info")]
    [Range(0.0f, 1.0f)] public float destructionChance;
    [Range(0.0f, 1.0f)] public float ratsKilledOnDestructionChance;

    [Header("Other configurations")]
    public Color ColorOnMouseEnter;
} 