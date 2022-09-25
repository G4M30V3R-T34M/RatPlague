using Feto;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrierManager : Singleton<CrierManager>
{
    [Header("General info text")]
    [SerializeField] TextMeshProUGUI scorePreviousText;
    [SerializeField] TextMeshProUGUI scoreCurrentText;
    [SerializeField] TextMeshProUGUI ratsPreviousText;
    [SerializeField] TextMeshProUGUI ratsCurrentText;
    [SerializeField] TextMeshProUGUI foodPreviousText;
    [SerializeField] TextMeshProUGUI foodCurrentText;

    [Header("Born and death info")]
    [SerializeField] TextMeshProUGUI bornText;
    [SerializeField] TextMeshProUGUI deathText;

    [Header("Buildings info")]
    [SerializeField] TextMeshProUGUI createdHouseText;
    [SerializeField] TextMeshProUGUI destroyedHouseText;
    [SerializeField] TextMeshProUGUI createdWareHouseText;
    [SerializeField] TextMeshProUGUI destroyedWareHouseText;
    [SerializeField] TextMeshProUGUI createdBarracsText;
    [SerializeField] TextMeshProUGUI destroyedBarracsText;

    [SerializeField] GameObject scrollCanvas;
    public int previousScore { get; set; }
    public int previousRats { get; set; }
    public int currentRats { get; set; }
    public int previousFood { get; set; }
    public int currentFood { get; set; }
    public int deathRats { get; set; }
    public int bornRats { get; set; }

    // This two dicts should be dicts
    public Dictionary<Buildings, int> destroyedBuildings { get; set; }
    public Dictionary<Buildings, int> newBuildings { get; set; }

    void Start()
    {
        previousScore = 0;
        currentRats = 0;
        currentFood = Street.Instance.food;
        bornRats = Street.Instance.rats;
    }

    public void SetUpTownCrier() {
        previousScore = ScoreManager.Instance.score;
        previousRats = currentRats;
        previousFood = currentFood;
        deathRats = 0;
        bornRats = 0;
        // Create new dictionaries
        destroyedBuildings = new Dictionary<Buildings, int>() {
            {Buildings.House, 0},
            {Buildings.Warehouse, 0},
            {Buildings.Military, 0}
        };
        newBuildings = new Dictionary<Buildings, int>() {
            {Buildings.House, 0},
            {Buildings.Warehouse, 0},
            {Buildings.Military, 0}
        };

    }

    public void DisplayInfo() {
        scrollCanvas.gameObject.SetActive(true);
        ScrollManager.Instance.SetUp();
        FillInfo();
    }

    private void FillInfo() {
        FillGeneralInfo();
        FillBornAndDeath();
        FillBuildings();
    }

    private void FillGeneralInfo() {
        // Score Text
        scorePreviousText.SetText(previousScore.ToString());
        scoreCurrentText.SetText(ScoreManager.Instance.score.ToString());
        scoreCurrentText.color = GetColorText(previousScore, ScoreManager.Instance.score);
        // Rats Text
        ratsPreviousText.SetText(previousRats.ToString());
        ratsCurrentText.SetText(currentRats.ToString());
        ratsCurrentText.color = GetColorText(previousRats, currentRats);
        // Food
        foodPreviousText.SetText(previousFood.ToString());
        foodCurrentText.SetText(currentFood.ToString());
        foodCurrentText.color = GetColorText(previousFood, currentFood);
    }

    private void FillBornAndDeath() {
        bornText.SetText(bornRats.ToString());
        deathText.SetText(deathRats.ToString());
    }

    private void FillBuildings() {
        // Destroyed Buildings
        destroyedHouseText.SetText(
            destroyedBuildings[Buildings.House].ToString()
        );
        destroyedWareHouseText.SetText(
            destroyedBuildings[Buildings.Warehouse].ToString()
        );
        destroyedBarracsText.SetText(
            destroyedBuildings[Buildings.Military].ToString()
        );
        // New buildings
        createdHouseText.SetText(
            newBuildings[Buildings.House].ToString()
        );
        createdWareHouseText.SetText(
            newBuildings[Buildings.Warehouse].ToString()
        );
        createdBarracsText.SetText(
            newBuildings[Buildings.Military].ToString()
        );
        

    }

    private Color GetColorText(int prevValue, int currValue) {
        if (prevValue == currValue) { return Color.black; }
        return prevValue < currValue ? Color.green : Color.red;
    }
}
