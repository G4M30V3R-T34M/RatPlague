using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class BaseTile : MonoBehaviour
{
    [SerializeField] protected BaseIconScriptable _settings;
    
    SpriteRenderer tileIcon;

    Color defaultColor;
    int assignedRats;

    protected void Awake() {
        tileIcon = GetComponent<SpriteRenderer>();
        GameManager.Instance.day += TileAction;
    }

    protected void Start() {
        defaultColor = tileIcon.color;
        assignedRats = 0;
    }

    protected virtual void TileAction() {}

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
}
