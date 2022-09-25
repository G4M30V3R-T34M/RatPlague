using UnityEngine;
using Feto;

public class GameOverManager : Singleton<GameOverManager>
{
    [SerializeField] GameObject newRecordStep1, newRecordStep2, noNewRecord;
    [SerializeField] LoadBestScores bestScoresNewRecord, bestScoresNoNewRecord;

    public string playerName;

    void Start() {
        if (BestScores.IsNewRecord(EndGameManager.Instance.score)) {
            newRecordStep1.SetActive(true);
            newRecordStep2.SetActive(false);
            noNewRecord.SetActive(false);
        } else {
            newRecordStep1.SetActive(false);
            newRecordStep2.SetActive(false);
            noNewRecord.SetActive(true);
            bestScoresNoNewRecord.Load();
        }
    }

    public void LoadNewRecordStep2() {
        BestScores.SaveScore(playerName, EndGameManager.Instance.score);
        newRecordStep1.SetActive(false);
        newRecordStep2.SetActive(true);
        noNewRecord.SetActive(false);
        bestScoresNewRecord.Load();
    }

}
