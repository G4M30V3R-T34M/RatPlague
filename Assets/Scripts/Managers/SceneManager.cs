using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static void ChangeScene(Scenes scene) {
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)scene);
    }
}
