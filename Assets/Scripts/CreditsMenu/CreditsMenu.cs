using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreditsMenu : MonoBehaviour
{
    [SerializeField] GameObject [] scrolls;

    [SerializeField] GameObject next;

    int page;

    private void Start() {
        for(int i = 0; i < scrolls.Length; i++) {
            scrolls[i].SetActive(false);
        }
        page = 0;
        scrolls[page].SetActive(true);
    }

    public void NextButtonAction() {
        scrolls[page].SetActive(false);
        page++;
        scrolls[page].SetActive(true);
        if (page == scrolls.Length - 1) {
            next.SetActive(false);
        }
    }

    public void BackButtonAction() {
        if(page == 0) {
            SceneManager.Instance.ChangeScene(Scenes.MainMenu);
        }
        else {
            scrolls[page].SetActive(false);
            page--;
            scrolls[page].SetActive(true);
            next.SetActive(true);
        }
    }
}
