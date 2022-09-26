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

    [Header("Scroll details")]
    [Tooltip("All details that should be hidden when crier assign")]
    [SerializeField] GameObject Scroll;

    [Header("Crier Assign")]
    [SerializeField] GameObject CrierAssign;


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
                Scroll.SetActive(true);
                GeneralInfo.SetActive(true);
                BornAndDeath.SetActive(false);
                Buildings.SetActive(false);
                CrierAssign.SetActive(false);
                nextScrollState = ScrollStates.BornAndDeath;
                prevScrollState = ScrollStates.None;
                PreviousButton.SetActive(false);
                break;
            case ScrollStates.BornAndDeath:
                GeneralInfo.SetActive(false);
                BornAndDeath.SetActive(true);
                Buildings.SetActive(false);
                PreviousButton.SetActive(true);
                CrierAssign.SetActive(false);
                nextScrollState = ScrollStates.Buildings;
                prevScrollState = ScrollStates.GeneralInfo;
                break;
            case ScrollStates.Buildings:
                Scroll.SetActive(true);
                GeneralInfo.SetActive(false);
                BornAndDeath.SetActive(false);
                Buildings.SetActive(true);
                CrierAssign.SetActive(false);
                nextScrollState = ScrollStates.Assign;
                prevScrollState = ScrollStates.BornAndDeath;
                break;
            case ScrollStates.Assign:
                Scroll.SetActive(false);
                GeneralInfo.SetActive(false);
                BornAndDeath.SetActive(false);
                Buildings.SetActive(false);
                CrierAssign.SetActive(true);
                prevScrollState = ScrollStates.Buildings;
                nextScrollState = ScrollStates.Exit;
                break;
            case ScrollStates.Exit:
                GameManager.Instance.UpdateGameState(GameStates.Play);
                gameObject.SetActive(false);
                break;
            case ScrollStates.None:
                break;
        }
    }
}
