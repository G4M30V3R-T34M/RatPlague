using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateBuildingCanvas : MonoBehaviour
{
    [SerializeField] BaseBuilding building;
    [SerializeField] TextMeshProUGUI occupation_text;

    int maxRats;

    void Start()
    {
        maxRats = building.settings.maxRats;
        int assigned = building.assignedRats;
        occupation_text.SetText(string.Format("{0}/{1}", assigned,  maxRats));
    }

    public void UpdateBuildingOccupation() {
        int assigned = building.assignedRats;
        occupation_text.SetText(string.Format("{0}/{1}", assigned, maxRats));
    }
}
