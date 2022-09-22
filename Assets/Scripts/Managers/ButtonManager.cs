using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void MainMenu() {
        SceneManager.ChangeScene(Scenes.MainMenu);
    }

    public void GamePlay() {
        SceneManager.ChangeScene(Scenes.GamePlay);
    }

    public void Tutorial() {
        SceneManager.ChangeScene(Scenes.Tutorial);
    }

    public void Scores() {
        SceneManager.ChangeScene(Scenes.BestScores);
    }

    public void Credits() {
        SceneManager.ChangeScene(Scenes.Credits);
    }

    public void Exit() {
        Application.Quit();
    }
}
