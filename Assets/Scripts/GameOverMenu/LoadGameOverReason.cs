using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadGameOverReason : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameOverReasonText;

    [SerializeField] string NoRatsReason, TooManyRatsReason, QuarantineReason;

    private void Start() {
        switch (EndGameManager.Instance.endGameCause) {
            case GameOverCondition.NoRats:
                gameOverReasonText.SetText(NoRatsReason);
                break;
            case GameOverCondition.TooManyRats:
                gameOverReasonText.SetText(TooManyRatsReason);
                break;
            case GameOverCondition.Quarantine:
                gameOverReasonText.SetText(QuarantineReason);
                break;
        }
    }
}
