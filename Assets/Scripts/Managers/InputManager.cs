using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] Camera mainCamera;

    void Update()
    {
        if (Input.GetButtonDown("LeftClick")) {
            bool isLeft = true;
            PerformClick(isLeft);
            
        } else if(Input.GetButtonDown("RightClick")) {
            bool isLeft = false;
            PerformClick(isLeft);
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
