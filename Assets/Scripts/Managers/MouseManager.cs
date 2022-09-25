using UnityEngine;
using Feto;

public class MouseManager : SingletonPersistent<MouseManager>
{
    [SerializeField] GameObject MousePointer;

    void Start() {
        Cursor.visible = false;
    }

    void Update() {
        MousePointer.transform.position = Input.mousePosition;
    }
}
