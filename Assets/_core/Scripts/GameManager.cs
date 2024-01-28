using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject transitionImage;
    [SerializeField] private Transform UIObject;
    public List<Condition> conditions = new List<Condition>();
    [SerializeField] private List <AudioClip> sfx;
    [SerializeField] private AudioSource playerAudioSource;

    public bool isSystemOperated = false;
    public static GameManager instance;


    public List<AudioClip> SFXlist { get { return sfx; } }
    public AudioSource PlayerAudioSource { get { return playerAudioSource; } }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(UIObject.gameObject);
    }
    #region Conditions
    public void AddCondition(Condition condition) // Called by Interactibles
    {
        conditions.Add(condition);
    }
    public void MarkConditionValue(Condition condition, bool value) // Called by Interactibles when triggered
    {
        if (conditions.Contains(condition))
        {
            condition.value = value;
        }
    }
    public bool GetConditionValue(string conditionName) //Called by objects who needs to check an condition
    {
        foreach (Condition condition in conditions)
        {
            if (condition.name == conditionName)
            {
                return condition.value;
            }
        }
        Debug.LogError("Condition not found");
        return false;
    }
    #endregion

    #region SceneManagement
    private void OnLevelWasLoaded(int scene) // Called when new scene finishes loading
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Hostel":
                transitionImage.GetComponent<Transition>().StartSwitchedScene();
                playerAudioSource = FindAnyObjectByType<Player>().GetComponent<AudioSource>();
                //Play your animations and effects here.
                break;
            case "GroundFloor":
                transitionImage.GetComponent<Transition>().StartSwitchedScene();
                playerAudioSource = FindAnyObjectByType<Player>().GetComponent<AudioSource>();
                break;
            case "Road":
                transitionImage.GetComponent<Transition>().StartSwitchedScene();
                playerAudioSource = FindAnyObjectByType<Player>().GetComponent<AudioSource>();
                break;
            case "ClassRoom":
                transitionImage.GetComponent<Transition>().StartSwitchedScene();
                playerAudioSource = FindAnyObjectByType<Player>().GetComponent<AudioSource>();
                break;
            case "FirstFloor":
                transitionImage.GetComponent<Transition>().StartSwitchedScene();
                playerAudioSource = FindAnyObjectByType<Player>().GetComponent<AudioSource>();
                break;
            case "Dream":
                transitionImage.GetComponent<Transition>().StartSwitchedScene();
                break;
            case "MainMenu":
                transitionImage.GetComponent<Transition>().StartSwitchedScene();
                break;




        }
    }
    public void LoadScene(string sceneName) //Called by Doors
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Road":
                transitionImage.GetComponent<Transition>().StartSceneSwitch(sceneName);
                break;
            case "GroundFloor":
                transitionImage.GetComponent<Transition>().StartSceneSwitch(sceneName);
                break;
            case "ClassRoom":
                transitionImage.GetComponent<Transition>().StartSceneSwitch(sceneName);
                break;
            case "FirstFloor":
                playerAudioSource.PlayOneShot(sfx[0]);
                transitionImage.GetComponent<Transition>().StartSceneSwitch(sceneName);
                break;
            case "Dream":
                transitionImage.GetComponent<Transition>().StartSceneSwitch(sceneName);
                break;
            case "Hostel":
                 transitionImage.GetComponent<Transition>().StartSceneSwitch(sceneName);
                break;
            case "MainMenu":
                transitionImage.GetComponent<Transition>().StartSceneSwitch(sceneName);
                break;
                //case "Road":
                //    //Play your animations and effects here.
                //    break;

        }

    }
    #endregion
}
