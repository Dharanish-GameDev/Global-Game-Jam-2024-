using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    private string nextSceneName; 
    public void StartSceneSwitch(string sceneName) // Called by gameManager, Takes care of Scenewitch by itself.
    {
        nextSceneName = sceneName;
        GetComponent<Animator>().Play("FadeIn");
    }
    public void StartSwitchedScene() // Called by gameManager after switching scene
    {
        GetComponent<Animator>().Play("FadeOut");
    }
    public void SwitchScene() // Called by the animation
    {
       SceneManager.LoadScene(nextSceneName);
    }
}
