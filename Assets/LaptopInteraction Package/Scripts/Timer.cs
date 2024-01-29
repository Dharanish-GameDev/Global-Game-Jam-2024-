using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private Transform BG;
    [SerializeField] private Transform BaseImage;
    [SerializeField] private Transform ComputerBorder;
    [SerializeField] private InteractablePC PC;
    [SerializeField] private GameObject PortalToFloor;

    [SerializeField] private GameObject tryagainDialogue, forgetpassDialogue;
    [SerializeField] private GameObject crashedDialogue;

    private int submitbtnCount;
    private int refreshCount;

    private void Awake()
    {
        submitbtnCount = 0;
        refreshCount = 0;
    }

    public void SubmitBtn()
    {
        if (submitbtnCount >= 2) return;

        submitbtnCount++;

        if (submitbtnCount == 1)
        {
            tryagainDialogue.SetActive(true);
            forgetpassDialogue.SetActive(false);
        }
        else if (submitbtnCount == 2)
        {
            tryagainDialogue.SetActive(false);
            forgetpassDialogue.SetActive(true);
        }
    }

    public void RefreshBtn()
    {
        if (refreshCount >= 5) return;

        refreshCount++;

        if (refreshCount >= 5)
        {
            BG.gameObject.SetActive(false);
            BaseImage.gameObject.SetActive(false);
            ComputerBorder.gameObject.SetActive(false);
            PC.playerRestricter.EnablePlayer();
            PC.Alret.gameObject.SetActive(false);
            Destroy(PC);
            PortalToFloor.SetActive(true);
            gameObject.SetActive(false);
            crashedDialogue.SetActive(true);
        }
    }
}
