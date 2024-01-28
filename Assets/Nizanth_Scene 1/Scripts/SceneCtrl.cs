using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCtrl : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [SerializeField] private DialogueManager s1Dialogue;
    [SerializeField] private GameObject s1Timeline;
    [SerializeField] private GameObject s1ToS2Timeline;
    [SerializeField] private GameObject alaramAudioSrc;


    private void Start()
    {
        if (s1Dialogue != null) s1Dialogue.OnDialogueComplete += Event_S1DialogueComplete;
    }

    private void Event_S1DialogueComplete()
    {
        s1Timeline.SetActive(false);
        s1ToS2Timeline.SetActive(true);
    }

    public void AlarmOffBtn()
    {
        alaramAudioSrc.SetActive(false);
        GameManager.instance.LoadScene("Hostel");
    }

    public void Deactivate()
    {
        GameManager.instance.LoadScene("Road");
        Invoke("DisableObj", 1f);
    }
    private void DisableObj()
    {
        obj.SetActive(false);
    }
}
