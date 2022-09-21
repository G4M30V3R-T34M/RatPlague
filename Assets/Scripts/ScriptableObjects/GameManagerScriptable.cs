using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameManagerScriptable", menuName = "Scriptables/GameManagerScriptable", order = 1)]
public class GameManagerScriptable : ScriptableObject
{
    public int daysPerIteration;
    public int totalIterations;
    public float secondsPerDay;
}
