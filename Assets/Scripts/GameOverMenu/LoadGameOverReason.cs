using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Localization;

public class LoadGameOverReason : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameOverReasonText;

    [SerializeField] LocalizedString NoRatsReason, TooManyRatsReason, QuarantineReason;

    private void Start() {
        switch (EndGameManager.Instance.endGameCause) {
            case GameOverCondition.NoRats:
                gameOverReasonText.SetText(NoRatsReason.GetLocalizedString());
                break;
            case GameOverCondition.TooManyRats:
                gameOverReasonText.SetText(TooManyRatsReason.GetLocalizedString());
                break;
            case GameOverCondition.Quarantine:
                gameOverReasonText.SetText(QuarantineReason.GetLocalizedString());
                break;
        }
    }
}
