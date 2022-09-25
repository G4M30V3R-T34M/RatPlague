using Feto;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : Singleton<HUDManager>
{
    [Header("General information")] 
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI ratsText;
    [SerializeField] TextMeshProUGUI foodText;

    public int totalRats;
    public int totalFood;

    public void UpdateGeneralInfoHUD() {
        scoreText.SetText(ScoreManager.Instance.score.ToString());
        ratsText.SetText(totalRats.ToString());
        foodText.SetText(totalFood.ToString());
    }
}
