using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    [SerializeField] private GameObject obj;

    private void OnEnable()
    {
        obj.SetActive(false);
        gameObject.SetActive(false);
    }
}
