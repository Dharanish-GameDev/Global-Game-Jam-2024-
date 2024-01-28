using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private Vector3 forwardVector;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private List<Transform> carWheels = new List<Transform>();
    [SerializeField] private float wheelRotateSpeed;
    [SerializeField] private bool isLeft;

    private void Update()
    {
        transform.position += forwardVector * Time.deltaTime;
        if(carWheels.Count > 0)
        {
            foreach (var carWheel in carWheels)
            {
                carWheel.Rotate(new Vector3(0, 0, wheelRotateSpeed) * Time.deltaTime);
            }
        }
        if(isLeft)
        {
            if (transform.position.x < endPoint.position.x)
            {
                transform.position = startPoint.position;
            }
        }
        else
        {
            if (transform.position.x > endPoint.position.x)
            {
                transform.position = startPoint.position;
            }
        }
        
        
    }
}
