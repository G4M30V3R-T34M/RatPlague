using Feto;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollManager : Singleton<ScrollManager>
{
    [Header("Scroll Views")]
    [SerializeField] GameObject GeneralInfo;
    [SerializeField] GameObject BornAndDeath;
    [SerializeField] GameObject Buildings;

    [Header("Buttons")]
    [SerializeField] GameObject PreviousButton;

    ScrollStates nextScrollState;
    ScrollStates prevScrollState;

    public void SetUp() {
        DoUpdateScrollState(ScrollStates.GeneralInfo);
    }

    public void NextUpdateScrollState() {
        DoUpdateScrollState(nextScrollState);
    }
    public void PrevUpdateScrollState() {
        DoUpdateScrollState(prevScrollState);
    }

    public void DoUpdateScrollState(ScrollStates nextState) {
        switch (nextState) {
            case ScrollStates.GeneralInfo:
                GeneralInfo.SetActive(true);
                BornAndDeath.SetActive(false);
                Buildings.SetActive(false);
                nextScrollState = ScrollStates.BornAndDeath;
                prevScrollState = ScrollStates.None;
                PreviousButton.SetActive(false);
                break;
            case ScrollStates.BornAndDeath:
                GeneralInfo.SetActive(false);
                BornAndDeath.SetActive(true);
                Buildings.SetActive(false);
                PreviousButton.SetActive(true);
                nextScrollState = ScrollStates.Buildings;
                prevScrollState = ScrollStates.GeneralInfo;
                break;
            case ScrollStates.Buildings:
                GeneralInfo.SetActive(false);
                BornAndDeath.SetActive(false);
                Buildings.SetActive(true);
                nextScrollState = ScrollStates.Exit;
                prevScrollState = ScrollStates.BornAndDeath;
                break;
            case ScrollStates.Exit:
                GameManager.Instance.UpdateGameState(GameStates.Pause);
                gameObject.SetActive(false);
                break;
            case ScrollStates.None:
                break;
        }
    }
}
