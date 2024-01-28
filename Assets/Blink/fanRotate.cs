using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fanRotate : MonoBehaviour
{
    [SerializeField] float speed;
   
    void Update()
    {
       Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(0, 0, -360 * Time.deltaTime * speed);
    }
}
