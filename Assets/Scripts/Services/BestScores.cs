using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BestScores
{
    const string NAME_KEY = "name", SCORE_KEY = "score";

    public static bool IsNewRecord(int value) {
        int score5th = PlayerPrefs.GetInt(SCORE_KEY + "5", 0);
        return value > score5th;
    }

    public static bool SaveScore(string name, int score) {
        int position = 1;
        bool found = false;

        string currentName = name;
        int currentScore = score;

        while (!found && position <= 5) {
            if (currentScore > GetScore(position)) {
                found = true;
            } else {
                position++;
            }
        }

        while (found && position <= 5){
            string auxName = currentName;
            int auxScore = currentScore;
            currentName = GetName(position);
            currentScore = GetScore(position);
            SetName(position, auxName);
            SetScore(position, auxScore);
            position++;
        }

        return found;
    }

    public static int GetScore(int position) {
        return PlayerPrefs.GetInt(SCORE_KEY + position.ToString(), 0);
    }

    public static string GetName(int position) {
        return PlayerPrefs.GetString(NAME_KEY + position.ToString(), "");
    }

    private static void SetScore(int position, int score) {
        PlayerPrefs.SetInt(SCORE_KEY + position.ToString(), score);
    }

    private static void SetName(int position, string name) {
        PlayerPrefs.SetString(NAME_KEY + position.ToString(), name);
    }
}
