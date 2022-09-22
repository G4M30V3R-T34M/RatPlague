using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] InputManagerScriptable _settings;
    [SerializeField] Camera mainCamera;

    Coroutine assignCoroutineReference;

    void Update()
    {
        if (Input.GetButtonDown("LeftClick") || Input.GetButtonDown("RightClick")) {
            bool isLeft = Input.GetButtonDown("LeftClick") ? true : false;
            if (assignCoroutineReference != null) {
                StopCoroutine(assignCoroutineReference);
            }
            assignCoroutineReference = StartCoroutine(AssignCoroutine(isLeft));

        }
    }

    private IEnumerator AssignCoroutine(bool isLeft) {
        string inputButton = isLeft ? "LeftClick" : "RightClick";
        float timeToNextAssign = _settings.startAssignTime;
        while (Input.GetButton(inputButton)) {
            PerformClick(isLeft);
            yield return new WaitForSeconds(timeToNextAssign);
            if (timeToNextAssign > _settings.minTimeAssign) {
                timeToNextAssign -= _settings.decrementTimeAssign;
            }
        }
    }

    private void PerformClick(bool isLeft) {
        RaycastHit2D hit = Physics2D.Raycast(mainCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit) {
            BaseTile tile = hit.collider.gameObject.GetComponent<BaseTile>();
            if (tile != null && isLeft) {
                tile.MouseLeftClick();
            } else if (tile != null) {
                tile.MouseRightClick();
            }
        }
    }
}
