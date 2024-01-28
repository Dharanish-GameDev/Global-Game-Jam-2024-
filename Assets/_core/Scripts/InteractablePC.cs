using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePC : Interactable
{
    public PlayerRestricter playerRestricter;
    [SerializeField] private GameObject websiteCanvas;


    public Transform Alret { get { return alert; } }
    public override void Interact()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            playerRestricter.DisablePlayer();
            websiteCanvas.SetActive(true);
            GameManager.instance.PlayerAudioSource.PlayOneShot(GameManager.instance.SFXlist[1]);
            GameManager.instance.isSystemOperated = true;
        }
    }
}
