using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class BaseTile : MonoBehaviour
{
    [SerializeField] protected BaseIconScriptable _settings;
    
    SpriteRenderer tileIcon;

    Color defaultColor;

    protected void Awake() {
        tileIcon = GetComponent<SpriteRenderer>();
        GameManager.Instance.day += TileAction;
    }

    protected void Start() {
        defaultColor = tileIcon.color;
    }

    protected virtual void TileAction() {}

    private void OnMouseEnter() {
        tileIcon.color = _settings.ColorOnMouseEnter;
        // TODO Get tile info to display
    }
    private void OnMouseExit() {
        tileIcon.color = defaultColor;
    }

    private void OnMouseDown() {
        // TODO assign mouse
    }
}
