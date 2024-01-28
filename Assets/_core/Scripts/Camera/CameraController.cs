using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject virtualCamera;
    [SerializeField] private CinemachineVirtualCamera virtualCam;
    [SerializeField] private Transform camStaticEnd;
    [SerializeField] private List <Transform> camMultipleEnd;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private bool isEndsInverted;


    public List<Transform> CamMultipleEnds { get { return camMultipleEnd; } }

    private void Update()
    {
        CameraBoundaryCheck();
    }

    private void CameraBoundaryCheck()
    {
            if (!isEndsInverted && (playerTransform.position.x < camStaticEnd.position.x || playerTransform.position.x > camMultipleEnd[0].position.x))
            {
                DisableVirtualCam();

            }
            else if(isEndsInverted && (playerTransform.position.x > camStaticEnd.position.x || playerTransform.position.x < camMultipleEnd[0].position.x))
            {
                 DisableVirtualCam();
            }
            else
            {
                EnableVirtualCam();
            }
    }

    private void EnableVirtualCam()
    {
        virtualCam.Follow = playerTransform;
    }
    private void DisableVirtualCam()
    {
        virtualCam.Follow = null;
    }

    public void RemoveFirstCamMultipleEnd()
    {
        camMultipleEnd.RemoveAt(0);
    }
}
