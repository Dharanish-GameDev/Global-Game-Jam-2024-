using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryingCanvasDisabler : MonoBehaviour
{
    [SerializeField] private PlayerRestricter m_Restricter;
    [SerializeField] private BedInteractable bedInteractable;
    [SerializeField] private GameObject mondayWakeUp;


    public void DisableCanvas()
    {
        foreach (GameObject canvasObject in bedInteractable.BedCanvasObjects)
        {
            canvasObject.SetActive(false);
        }
        Destroy(bedInteractable.Alert.gameObject);
        Destroy(bedInteractable);
    }

    public void EnableNextDay()
    {
        Invoke(nameof(EnableNextDayInvoke), 1.7f);
    }
    private void EnableNextDayInvoke()
    {
        mondayWakeUp.SetActive(true);
    }

    public void EnablePlayer()
    {
        m_Restricter.EnablePlayer();
    }
}
