using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    [SerializeField] private Transform destroyPoint;
    [SerializeField] private GameObject dogDialogue;

    private void Update()
    {
        transform.Rotate(0,0,250 * Time.deltaTime);
        transform.position -= new Vector3(6,0,0) * Time.deltaTime;
        if(transform.position.x < destroyPoint.position.x)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        dogDialogue.SetActive(true);
    }
}
