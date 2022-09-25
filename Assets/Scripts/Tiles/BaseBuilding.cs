using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class BaseBuilding : MonoBehaviour
{
    [SerializeField] protected BaseBuildingScriptable _settings;
    
    SpriteRenderer tileIcon;
    protected new Collider2D collider;

    Color defaultColor;
    public int assignedRats { get; protected set; }
    protected int currentFood;

    private bool executedStart = false;

    protected virtual void Awake() {
        tileIcon = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
    }

    protected virtual void Start() {
        defaultColor = tileIcon.color;
        assignedRats = 0;
        executedStart = true;
        OnEnable();
    }

    private void OnEnable() {
        if (executedStart) {
            GameManager.Instance.day += DayAction;
            GameManager.Instance.townCrierDelegate += TownCrierAction;
            RatManager.Instance.AddBuilding(this);
        }
    }

    private void OnDisable() {
        if (GameManager.Instance != null) {
            GameManager.Instance.day -= DayAction;
            GameManager.Instance.townCrierDelegate -= TownCrierAction;
        }
        if (RatManager.Instance != null) {
            RatManager.Instance.RemoveBuilding(this);
        }
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
