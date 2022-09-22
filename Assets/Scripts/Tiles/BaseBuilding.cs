using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class BaseTile : MonoBehaviour
{
    [SerializeField] protected BaseBuildingScriptable _settings;
    
    SpriteRenderer tileIcon;

    Color defaultColor;
    protected int assignedRats;
    protected int currentFood;

    protected void Awake() {
        tileIcon = GetComponent<SpriteRenderer>();
    }

    protected void Start() {
        defaultColor = tileIcon.color;
        assignedRats = 0;
    }

    private void OnEnable() {
        GameManager.Instance.day += DayAction;
        GameManager.Instance.townCrier += TownCrierAction;
    }

    private void OnDisable() {
        GameManager.Instance.day -= DayAction;
        GameManager.Instance.townCrier -= TownCrierAction;
    }

    protected abstract void DayAction();
    protected abstract void TownCrierAction();

    private void OnMouseEnter() {
        tileIcon.color = _settings.ColorOnMouseEnter;
        // TODO Get tile info to display
    }

    private void OnMouseExit() {
        tileIcon.color = defaultColor;
    }

    public void MouseLeftClick(int iteration) {
        int ratsToAssign = 1; // TODO change this to use with iterations
        if (Street.Instance.HasAvaibleRats(ratsToAssign)) {
            assignedRats += ratsToAssign;
            Street.Instance.Unassign(ratsToAssign);
        }
    }

    public void MouseRightClick(int iteration) {
        int ratsToUnassign = 1; // TODO change this to use with ireations
        if (assignedRats >= ratsToUnassign) {
            assignedRats -= ratsToUnassign;
            Street.Instance.Assign(ratsToUnassign);
        }
    }

    public float GetRatOccupationRatio() {
        return assignedRats / _settings.maxRats;
    }

}
