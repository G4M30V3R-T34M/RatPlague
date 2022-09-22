using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] Canvas pauseCanvas;
    void Update()
    {
        if (Input.GetButtonDown("Pause")) {
            Time.timeScale = Time.timeScale == 1 ? 0 : 1;
            pauseCanvas.gameObject.SetActive(
                !pauseCanvas.gameObject.active);
        }
        
    }
}
