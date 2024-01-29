using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondTimeFirstFloor : MonoBehaviour
{
    [SerializeField] private Transform classExitPoint;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private Door classDoor;

    [SerializeField] private GameObject introDialogue;

    void Start()
    {
        if(GameManager.instance.isSystemOperated)
        {
            introDialogue.SetActive(false);
            playerTransform.position = classExitPoint.position;
            cameraController.RemoveFirstCamMultipleEnd();
            Destroy(classDoor);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
