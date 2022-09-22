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
        int iteration = 0;
        while (Input.GetButton(inputButton)) {
            PerformClick(isLeft, iteration);
            yield return new WaitForSeconds(timeToNextAssign);
            iteration++;
            if (timeToNextAssign > _settings.minTimeAssign) {
                timeToNextAssign -= _settings.decrementTimeAssign;
            }
        }
    }

    private void PerformClick(bool isLeft, int iteration) {
        RaycastHit2D hit = Physics2D.Raycast(mainCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit) {
            BaseBuilding building = hit.collider.gameObject.GetComponent<BaseBuilding>();
            if (building != null && isLeft) {
                building.MouseLeftClick(iteration);
            } else if (building != null) {
                building.MouseRightClick(iteration);
            }
        }
    }
}
