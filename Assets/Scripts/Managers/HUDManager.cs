using Feto;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Localization.Components;
using UnityEngine.Localization;

public class HUDManager : Singleton<HUDManager>
{
    [Header("Day information")]
    [SerializeField] TextMeshProUGUI dayText;

    [Header("General information")] 
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI ratsText;
    [SerializeField] TextMeshProUGUI foodText;

    [Header("Building information")]
    [SerializeField] TextMeshProUGUI buildingNameText;
    [SerializeField] TextMeshProUGUI buildingDescriptionText;
    [SerializeField] TextMeshProUGUI buildingRatsText;
    [SerializeField] TextMeshProUGUI buildingFoodText;

    // General info
    public int totalDays;
    public int totalRats;
    public int totalFood;

    // Building info
    public string buildingName;
    public string buildingDescription;
    public int buildingCurrentRats;
    public int buildingMaxRats;
    public int buildingFood;

    public bool StreetSelected = true;

    [SerializeField] LocalizedString street_name;
    [SerializeField] LocalizedString street_description;

    private void Start() {
        GameManager.Instance.dayDelegate += UpdateStreetData;
    }

    protected override void OnDestroy() {
        if (GameManager.Instance != null) {
            GameManager.Instance.dayDelegate -= UpdateStreetData;
        }
        base.OnDestroy();
    }

    protected void UpdateStreetData() {
        if (StreetSelected) {
            UpdateStreetInfoHUD();
        }
    }


    public void UpdateGeneralInfoHUD() {
        dayText.SetText(totalDays.ToString());
        scoreText.SetText(ScoreManager.Instance.score.ToString());
        ratsText.SetText(totalRats.ToString());
        foodText.SetText(totalFood.ToString());
    }

    public void UpdateBuildingInfoHUD() {
        StreetSelected = false;
        buildingNameText.SetText(buildingName);
        buildingDescriptionText.SetText(buildingDescription);
        buildingRatsText.SetText(
            string.Format("{0} / {1}", 
            buildingCurrentRats, 
            buildingMaxRats
        ));
        buildingFoodText.SetText(buildingFood.ToString());
    }

    public void UpdateStreetInfoHUD() {
        StreetSelected = true;
        buildingNameText.SetText(street_name.GetLocalizedString());
        buildingDescriptionText.SetText(street_description.GetLocalizedString());
        buildingRatsText.SetText(Street.Instance.rats.ToString());
        buildingFoodText.SetText(Street.Instance.food.ToString());
    }
}
