using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeDoor : MonoBehaviour
{
    [SerializeField] private List<GameObject> OfficeScene;
    [SerializeField] private GameObject bgAudioSrc;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            bgAudioSrc.SetActive(false);
            foreach(var obj in OfficeScene)
            {
                obj.SetActive(true);
            }
        }
    }
}
