using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InputManagerScriptable", menuName = "Scriptables/Managers/InputManagerScriptable")]
public class InputManagerScriptable : ScriptableObject
{
    [Header("Time between assign configuration")]
    public float startAssignTime;
    public float minTimeAssign;
    public float decrementTimeAssign;
}
