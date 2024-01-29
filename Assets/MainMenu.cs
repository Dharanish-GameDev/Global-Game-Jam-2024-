using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject eventSystemObj;

    private void Awake()
    {
        if (GameManager.instance) Destroy(eventSystemObj);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Dream");
    }
    public void Exitgame()
    {
        Application.Quit();
    }
}
