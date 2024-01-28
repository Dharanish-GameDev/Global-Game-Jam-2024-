using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    [SerializeField] private GameObject timeLineObject;

    private void Awake()
    {
        timeLineObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            timeLineObject.SetActive(true);
            Collider2D selfColli = GetComponent<Collider2D>();
            Destroy(selfColli);
        }
    }
}
