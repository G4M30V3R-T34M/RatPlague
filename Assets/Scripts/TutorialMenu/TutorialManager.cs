using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject[] tutorialSteps;
    [SerializeField] GameObject prevButton, nextButton;

    int currentStep = 0;

    private void Start() {
        ActivateCurrentStep();
    }

    private void ActivateCurrentStep() {
        for (int i = 0; i < tutorialSteps.Length; i++) {
            tutorialSteps[i].SetActive(i == currentStep);
        }

        prevButton.SetActive(currentStep > 0);
        nextButton.SetActive(currentStep < tutorialSteps.Length - 1);
    }

    public void NextStep() {
        currentStep++;
        ActivateCurrentStep();
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void PrevStep() {
        currentStep--;
        ActivateCurrentStep();
        EventSystem.current.SetSelectedGameObject(null);
    }
}
