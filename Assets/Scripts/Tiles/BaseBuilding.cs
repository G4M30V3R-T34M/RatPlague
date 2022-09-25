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

    private Coroutine UpdateBuildingHUDCoroutine;

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
            GameManager.Instance.dayDelegate += DayAction;
            GameManager.Instance.townCrierDelegate += TownCrierAction;
            RatManager.Instance.AddBuilding(this);
        }
    }

    private void OnDisable() {
        if (GameManager.Instance != null) {
            GameManager.Instance.dayDelegate -= DayAction;
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
        // Display info of the tile
        DisplayBuildingInfo();
        GameManager.Instance.dayDelegate += UpdateBuildingHUD;
    }

    private void DisplayBuildingInfo() {
        HUDManager.Instance.buildingName = _settings.buildingName;
        HUDManager.Instance.buildingDescription = _settings.buildingDescription;
        HUDManager.Instance.buildingCurrentRats = assignedRats;
        HUDManager.Instance.buildingMaxRats = _settings.maxRats;
        HUDManager.Instance.buildingFood = currentFood;
        HUDManager.Instance.UpdateBuildingInfoHUD();
    }

    private void OnMouseExit() {
        tileIcon.color = defaultColor;
        HUDManager.Instance.UpdateStreetInfoHUD();
        GameManager.Instance.dayDelegate -= UpdateBuildingHUD;
        if(UpdateBuildingHUDCoroutine != null) {
            StopCoroutine(UpdateBuildingHUDCoroutine);
        }
    }

    public void MouseLeftClick(int iteration) {
        int ratsToAssign = 1; // TODO change this to use with iterations
        if (Street.Instance.HasAvaibleRats(ratsToAssign)) {
            print(ratsToAssign);
            assignedRats += ratsToAssign;
            Street.Instance.Unassign(ratsToAssign);
        }
        DisplayBuildingInfo();
    }

    public void MouseRightClick(int iteration) {
        int ratsToUnassign = 1; // TODO change this to use with ireations
        if (assignedRats >= ratsToUnassign) {
            assignedRats -= ratsToUnassign;
            Street.Instance.Assign(ratsToUnassign);
        }
        DisplayBuildingInfo();
    }

    public float GetRatOccupationRatio() {
        return assignedRats / _settings.maxRats;
    }

    protected void UpdateBuildingHUD() {
        if (UpdateBuildingHUDCoroutine != null) {
            StopCoroutine(UpdateBuildingHUDCoroutine);
        }
        UpdateBuildingHUDCoroutine = StartCoroutine(UpdateHUDCoroutine());
    }

    protected IEnumerator UpdateHUDCoroutine() {
        yield return null;
        DisplayBuildingInfo();
    }

}
