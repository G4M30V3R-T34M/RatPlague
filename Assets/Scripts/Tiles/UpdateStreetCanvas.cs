using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateStreetCanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI occupation_text;
    void Start()
    {
        occupation_text.SetText(Street.Instance.rats.ToString());
    }

    private void OnEnable() {
        Street.Instance.updateOccupation += UpdateOccupation;
    }

    private void OnDisable() {
        Street.Instance.updateOccupation -= UpdateOccupation;
    }

    public void UpdateOccupation() {
        occupation_text.SetText(Street.Instance.rats.ToString());
    }
}
