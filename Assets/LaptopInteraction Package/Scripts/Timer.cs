using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float timer;
    [SerializeField] private Transform BG;
    [SerializeField] private Transform BaseImage;
    [SerializeField] private Transform ComputerBorder;
    [SerializeField] private InteractablePC PC;
    [SerializeField] private GameObject PortalToFloor;
    private void OnEnable()
    {
        timer = 10; 
    }

    private void Update()
    {
        timer-=Time.deltaTime;

        if(timer <= 0)
        {
            BG.gameObject.SetActive(false);
            BaseImage.gameObject.SetActive(false);
            ComputerBorder.gameObject.SetActive(false);
            PC.playerRestricter.EnablePlayer();
            PC.Alret.gameObject.SetActive(false);
            Destroy(PC);
            PortalToFloor.SetActive(true);
            gameObject.SetActive(false);

        }
    }
}
