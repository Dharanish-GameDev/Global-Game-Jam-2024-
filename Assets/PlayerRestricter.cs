using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRestricter : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private List<SpriteRenderer> playerSprites;
    [SerializeField] private CameraController playerCameraController;
    [SerializeField] private GameObject canvasObject;
    [SerializeField] private Color ShadowColor;
    private Color tempColor = Color.white;
    [SerializeField] private GameObject liftDialogue;

    public void EnablePlayer()
    {
        playerRb.constraints = RigidbodyConstraints2D.None;
        playerRb.constraints = RigidbodyConstraints2D.FreezePositionY;
        playerRb.constraints = RigidbodyConstraints2D.FreezeRotation;
        tempColor.a = 0;
        tempColor = Color.white;
        while (playerSprites[0].color.a < 1)
        {
            tempColor.a += 2 * Time.deltaTime;
            foreach (var sprite in playerSprites)
            {
                sprite.color = tempColor;
            }
        }
        playerSprites[10].color = ShadowColor;
        if (playerCameraController == null) return;
        if (playerCameraController.CamMultipleEnds.Count > 1)
        {
            playerCameraController.RemoveFirstCamMultipleEnd();
        }
    }

    public void DisableCanvas()
    {
        canvasObject.SetActive(false);
        liftDialogue.SetActive(true);
    }
    public void DisablePlayer()
    {
        playerRb.constraints = RigidbodyConstraints2D.FreezePositionX;
        tempColor = Color.white;
        tempColor.a = 1;
        while (playerSprites[0].color.a > 0)
        {
            tempColor.a -= Time.deltaTime * 0.01f; ;
            foreach (var sprite in playerSprites)
            {
                sprite.color = tempColor;
            }
        }
    }
}
