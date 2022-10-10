using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Feto;

[RequireComponent(typeof(Collider2D))]
public abstract class BaseBuilding : MonoBehaviour
{
    [SerializeField] protected BaseBuildingScriptable _settings;
    [SerializeField] UpdateBuildingCanvas canvas;
    public BaseBuildingScriptable settings {
        get { return _settings; }
        protected set { _settings = value; } 
    }
    
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
        ResetValues();
        executedStart = true;
        OnEnable();
    }

    public void ResetValues() {
        defaultColor = tileIcon.color;
        assignedRats = 0;
        currentFood = _settings.startingFood;
    }

    private void OnEnable() {
        if (executedStart) {
            GameManager.Instance.dayDelegate += DayAction;
            GameManager.Instance.townCrierDelegate += TownCrierAction;
            if(_settings.buildingName != Buildings.Ship) {
                RatManager.Instance.AddBuilding(this);
            }
            canvas.UpdateBuildingOccupation();
        }
    }
    
    protected void DestroyBuilding() {
        BuildingsManager.Instance.DestroyBuilding(this, _settings);
    }

    protected void OnDisable() {
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
        HUDManager.Instance.buildingName = _settings.buildingName.ToString();
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
        if (Street.Instance.HasAvaibleRats(ratsToAssign)
                && assignedRats < _settings.maxRats) {
            assignedRats += ratsToAssign;
            Street.Instance.Unassign(ratsToAssign);
        }
        DisplayBuildingInfo();
        canvas.UpdateBuildingOccupation();
    }

    public void MouseRightClick(int iteration) {
        int ratsToUnassign = 1; // TODO change this to use with ireations
        if (assignedRats >= ratsToUnassign) {
            assignedRats -= ratsToUnassign;
            Street.Instance.Assign(ratsToUnassign);
        }
        DisplayBuildingInfo();
        canvas.UpdateBuildingOccupation();
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
