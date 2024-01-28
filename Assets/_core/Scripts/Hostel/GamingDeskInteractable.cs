using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamingDeskInteractable : Interactable
{
    public List<GameObject> GamingCanvasObjects;
    [SerializeField] private PlayerRestricter playerRestricter;

    public Transform Alert { get { return alert; } }
    public override void Interact()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            playerRestricter.DisablePlayer();
            foreach(GameObject obj in GamingCanvasObjects)
            {
                obj.SetActive(true);
            }
        }
    }
}
