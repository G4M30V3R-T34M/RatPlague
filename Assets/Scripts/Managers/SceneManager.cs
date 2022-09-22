using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static void DoChangeScene(Scenes scene) {
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)scene);
    }
}
