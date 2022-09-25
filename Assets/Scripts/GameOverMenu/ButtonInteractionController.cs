using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInteractionController : MonoBehaviour
{
    Button nextButton;

    private void Awake() {
        nextButton = GetComponent<Button>();
    }

    public void CheckButtonInteractable(string value) {
        nextButton.interactable = (value != "");
    }

}
