using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedInteractable : Interactable
{
    public List<GameObject> BedCanvasObjects;
    [SerializeField] private PlayerRestricter playerRestricter;
    [SerializeField] private GameObject bgAudioSrc;
    public Transform Alert { get { return alert; } }

    public override void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            bgAudioSrc.SetActive(false);
            playerRestricter.DisablePlayer();
            foreach (GameObject obj in BedCanvasObjects)
            {
                obj.SetActive(true);
            }
        }
    }
}
