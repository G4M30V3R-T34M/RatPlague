using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void MainMenu() {
        Time.timeScale = 1;
        SceneManager.ChangeScene(Scenes.MainMenu);
    }

    public void GamePlay() {
        Time.timeScale = 1;
        SceneManager.ChangeScene(Scenes.GamePlay);
    }

    public void Tutorial() {
        Time.timeScale = 1;
        SceneManager.ChangeScene(Scenes.Tutorial);
    }

    public void Scores() {
        Time.timeScale = 1;
        SceneManager.ChangeScene(Scenes.BestScores);
    }

    public void Credits() {
        Time.timeScale = 1;
        SceneManager.ChangeScene(Scenes.Credits);
    }

    public void Resume() {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }

    public void Exit() {
        Application.Quit();
    }
}
