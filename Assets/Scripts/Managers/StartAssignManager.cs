using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Feto;

public class StartAssignManager : Singleton<StartAssignManager>
{
    public void StartGame() {
        GameManager.Instance.UpdateGameState(GameStates.Play);
        this.gameObject.SetActive(false);
    }
}
