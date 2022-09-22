using UnityEngine;
using Feto;

public class MouseManager : SingletonPersistent<MouseManager>
{
    Camera mainCamera;

    void Start() {
        Cursor.visible = false;
    }

    void Update() {
        if (mainCamera == null) { FindMainCamera(); }
        Vector2 position = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = position;
    }

    private void FindMainCamera() {
        mainCamera = Camera.main;
    }
}
