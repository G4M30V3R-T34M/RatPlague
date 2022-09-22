using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameManagerScriptable", menuName = "Scriptables/Managers/GameManagerScriptable")]
public class GameManagerScriptable : ScriptableObject
{
    public int daysPerIteration;
    public int totalIterations;
    public float secondsPerDay;
}
