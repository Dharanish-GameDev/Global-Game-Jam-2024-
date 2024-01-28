using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Transform alert;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().SetSelectedInteractible(this);
            alert.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.GetComponent<Player>().SetSelectedInteractible(null);
        alert.gameObject.SetActive(false);
    }

    public virtual void Interact()
    {
        Debug.Log("Interacted");
    }
}
