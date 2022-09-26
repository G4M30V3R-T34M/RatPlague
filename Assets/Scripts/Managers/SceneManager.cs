using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Feto;

public class SceneManager : Singleton<SceneManager>
{
    Animator animator;

    int nextScene;
    bool animating = false;

    private void Start() {
        animator = GetComponentInChildren<Animator>();
    }

    public void ChangeScene(Scenes scene) {
        if (!animating) {
            animating = true;
            nextScene = (int)scene;
            animator.SetTrigger("SceneOut");
        }
    }

    public void DoChangeScene() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
    }
}
