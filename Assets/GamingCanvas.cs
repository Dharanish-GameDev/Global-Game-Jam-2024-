using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamingCanvas : MonoBehaviour
{
    [SerializeField] private PlayerRestricter m_Restricter;
    [SerializeField] private GamingDeskInteractable gamingDeskInteractable;
    [SerializeField] private BoxCollider2D bedBoxCollider;
    [SerializeField] private GameObject bedDialogue;

    public void DisableCanvas()
    {
        foreach(GameObject canvasObject in gamingDeskInteractable.GamingCanvasObjects)
        {
            canvasObject.SetActive(false);
        }
        Destroy(gamingDeskInteractable.Alert.gameObject);
        Destroy(gamingDeskInteractable);
        bedBoxCollider.enabled = true;
        bedDialogue.SetActive(true);
    }


    public void EnablePlayer()
    {
        m_Restricter.EnablePlayer();
    }
}
