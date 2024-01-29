using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadToMenu : MonoBehaviour
{
    public void LoadScene(string name)
    {
        GameManager.instance.LoadScene(name);
    }
}
